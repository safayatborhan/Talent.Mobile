using DevenvExeBehaviors;
using ImageCircle.Forms.Plugin.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Common;
using Talent.Mobile.Context;
using Talent.Mobile.Controls;
using Talent.Mobile.Controls.Cell;
using Talent.Mobile.CustomRenderer;
using Talent.Mobile.Models;
using Talent.Mobile.Models.College;
using Talent.Mobile.Models.InterviewModels;
using Talent.Mobile.Models.Models;
using Talent.Mobile.Models.University;
using Xamarin.Forms;

namespace Talent.Mobile.Pages.User
{
    class InterviewMatrix : BasePage
    {
        #region constructor               
        public InterviewMatrix()
        {
            List<Models.CandidateDetails> candidateListForIm = new List<Models.CandidateDetails>();
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    var resultCandidateListForIm = await Service.GetCandidateListForIM();
                    if (resultCandidateListForIm != null)
                    {
                        candidateListForIm = (List<Models.CandidateDetails>)JsonConvert.DeserializeObject<List<Models.CandidateDetails>>(resultCandidateListForIm);             
                        InterviewMatrixLayout(candidateListForIm);
                    }
                }
                catch(Exception exp)
                {

                }
            });
        }
        #endregion

        #region initialize
        CustomEntryForGeneralPurpose lineItemAdd = new CustomEntryForGeneralPurpose();

        StackLayout slCandidateEditInfo = new StackLayout();
        StackLayout sInterviewRoundEdit = new StackLayout();
        Button btnSaveData = new Button();



        Picker pkrCandidateName = new Picker();
        TapGestureRecognizer recognizerCandidateName = new TapGestureRecognizer();

        StackLayout slCandidateInformation = new StackLayout();
        InterviewsModel interviewsModel = new InterviewsModel();

        InterviewsModel canditeDetailWithInterview = new InterviewsModel();

        ListView listViewLineItemDetail = new ListView();

        ListView listView = new ListView();

        StackLayout slHeaderText = new StackLayout();
        StackLayout sListView = new StackLayout();
        StackLayout sSeparatorListviewInterviewRounds = new StackLayout();

        StackLayout slHeaderTextForLineItem = new StackLayout();
        StackLayout sListViewLineItemDetail = new StackLayout();
        Seperator spForLineItemDetail = new Seperator();

        CustomEntryForGeneralPurpose overallRemarkAdd = new CustomEntryForGeneralPurpose();
        CustomEntryForGeneralPurpose averageRatingAdd = new CustomEntryForGeneralPurpose();

        Seperator spOverallRemarkAdd = new Seperator();
        StackLayout sOverallRemarkAdd = new StackLayout();

        Seperator spAverageRatingAdd = new Seperator();
        StackLayout sAverageRatingAdd = new StackLayout();

        StackLayout sSwithForCandidateSelected = new StackLayout();

        StackLayout sSwithForCandidateMoveToNextRound = new StackLayout();

        StackLayout slAfterSaveResponseAllInformation = new StackLayout();
        StackLayout sbtnSaveAllInfo = new StackLayout();

        Seperator spLineItemAdd = new Seperator();
        StackLayout slineItemAdd = new StackLayout();

        StackLayout slAfterSaveResponseLineItem = new StackLayout();

        StackLayout sbtnSaveDataLineItem = new StackLayout();
        #endregion

        public void InterviewMatrixLayout(List<Models.CandidateDetails> candidateListForIm)
        {
            if (ACTContext.isLogin == true)
            {

                #region header text
                Label lblInterviewMatrixInfo = new Label { Text = "Interview Matrix", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.FromHex("5e247f"), FontSize = 18, FontAttributes = FontAttributes.Bold, HeightRequest = 30 };
                Label interviewMatrixInfo = new Label { Text = "", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, HeightRequest = 40 };
                StackLayout sInterviewMatrixInfo = new StackLayout
                {
                    Children = { lblInterviewMatrixInfo, interviewMatrixInfo },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 50, 0, 0)
                };
                #endregion

                #region candidate name
                Label lblCandidatePickerTitle = new Label { Text = "Candidate Name", TextColor = Color.Gray };
                pkrCandidateName = new Picker { IsVisible = false };
                pkrCandidateName.Title = "Candidate Name";
                foreach (CandidateDetails item in candidateListForIm)
                {
                    pkrCandidateName.Items.Add(item.CandidateName.ToString());
                }
                pkrCandidateName.SelectedIndexChanged += (s, e) =>
                {
                    lblCandidatePickerTitle.TextColor = Color.Black;
                    lblCandidatePickerTitle.Text = pkrCandidateName.Items[pkrCandidateName.SelectedIndex].ToString();
                };
                Image imgPkrCandidateNameDropdown = new Image { Source = "dropdownPicker.png", HorizontalOptions = LayoutOptions.EndAndExpand };

                StackLayout sPkrCandidateName = new StackLayout { Children = { lblCandidatePickerTitle, pkrCandidateName, imgPkrCandidateNameDropdown }, Orientation = StackOrientation.Horizontal, Padding = new Thickness(0, 5, 0, 5) };
                Frame frmPkrCandidateName = new Frame { Content = sPkrCandidateName, BackgroundColor = Color.White, Padding = new Thickness(Device.OnPlatform(8, 5, 0)), HasShadow = false };

                recognizerCandidateName.NumberOfTapsRequired = 1;
                recognizerCandidateName.Tapped += (s, e) =>
                {
                    pkrCandidateName.Focus();
                };
                frmPkrCandidateName.GestureRecognizers.Add(recognizerCandidateName);
                Seperator candidateNameSeparator = new Seperator();


                Button btnSubmitCandidate = new Button { Text = "Submit", HorizontalOptions = LayoutOptions.StartAndExpand, BackgroundColor = Color.FromHex("4690FB"), TextColor = Color.White, BorderRadius = 10, WidthRequest = 80, FontAttributes = FontAttributes.None, HeightRequest = 40 };
                StackLayout sBtnSubmitCandidate = new StackLayout
                {
                    Children = { btnSubmitCandidate },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 5, 0, 5)
                };

                #endregion

                #region candidate information

                #region first name
                //First Name
                Label lblCandidateFirstName = new Label { Text = "First name : ", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 90 };
                Label lblCandidateFirstNameText = new Label { Text = "demo demo demo", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black };
                StackLayout slblCandidateFirstName = new StackLayout
                {
                    Children = { lblCandidateFirstName, lblCandidateFirstNameText },
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Margin = new Thickness(0, 10, 0, 10)
                };
                Seperator separatorFirstName = new Seperator();
                #endregion

                #region last name
                //Last Name
                Label lblCandidateLastName = new Label { Text = "Last name : ", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 90 };
                Label lblCandidateLastNameText = new Label { Text = "demo demo", HorizontalOptions = LayoutOptions.StartAndExpand, TextColor = Color.Black };
                StackLayout slblCandidateLastName = new StackLayout
                {
                    Children = { lblCandidateLastName, lblCandidateLastNameText },
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Margin = new Thickness(0, 10, 0, 10)
                };
                Seperator separatorLastName = new Seperator();
                #endregion

                #region address
                //Address
                Label lblCandidateAddress = new Label { Text = "Address : ", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 90 };
                Label lblCandidateAddressText = new Label { Text = "demo address", HorizontalOptions = LayoutOptions.StartAndExpand, TextColor = Color.Black };
                StackLayout slblCandidateAddress = new StackLayout
                {
                    Children = { lblCandidateAddress, lblCandidateAddressText },
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Margin = new Thickness(0, 10, 0, 10)
                };
                Seperator separatorAddress = new Seperator();
                #endregion

                #region educational qualification
                //Educational qualification
                Label lblCandidateEducationalQualification = new Label { Text = "Educational Qualification : ", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 90 };
                Label lblCandidateEducationalQualificationText = new Label { Text = "demo qualification", HorizontalOptions = LayoutOptions.StartAndExpand, TextColor = Color.Black };
                StackLayout slblCandidateEducationalQualification = new StackLayout
                {
                    Children = { lblCandidateEducationalQualification, lblCandidateEducationalQualificationText },
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Margin = new Thickness(0, 10, 0, 10)
                };
                Seperator separatorEducationalQualification = new Seperator();
                #endregion

                #region candidate information stack layout
                slCandidateInformation = new StackLayout
                {
                    Children = { slblCandidateFirstName,separatorFirstName,
                    slblCandidateLastName, separatorLastName,
                    slblCandidateAddress, separatorAddress,
                    slblCandidateEducationalQualification, separatorEducationalQualification}
                };
                slCandidateInformation.IsVisible = false;
                #endregion

                #region submit button click
                btnSubmitCandidate.Clicked += (object sender, EventArgs e) =>
                {
                    if (Validate())
                    {
                        slCandidateInformation.IsVisible = true;

                        sListView.IsVisible = true;
                        slHeaderText.IsVisible = true;
                        sSeparatorListviewInterviewRounds.IsVisible = true;

                        slHeaderTextForLineItem.IsVisible = true;
                        sListViewLineItemDetail.IsVisible = true;
                        spForLineItemDetail.IsVisible = true;

                        sOverallRemarkAdd.IsVisible = true;
                        spOverallRemarkAdd.IsVisible = true;

                        sAverageRatingAdd.IsVisible = true;
                        spAverageRatingAdd.IsVisible = true;

                        sSwithForCandidateSelected.IsVisible = true;

                        sSwithForCandidateMoveToNextRound.IsVisible = true;

                        slAfterSaveResponseAllInformation.IsVisible = true;
                        sbtnSaveAllInfo.IsVisible = true;

                        slineItemAdd.IsVisible = true;
                        spLineItemAdd.IsVisible = true;

                        slAfterSaveResponseLineItem.IsVisible = true;

                        sbtnSaveDataLineItem.IsVisible = true;

                        int candidateId = (from c in candidateListForIm where c.CandidateName == pkrCandidateName.Items[pkrCandidateName.SelectedIndex] select c.CandidateId).SingleOrDefault();
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                        //var result = await Service.GetCandidateInformation(interviewId2, ACTContext.interviewerId);
                        var result = await Service.GetCandidateDetailWithInterview(candidateId, 1);
                            var resultCandidateDetailListWithInterview = await Service.GetCandidateDetailWithInterview(candidateId, 1);
                            if (result != null)
                            {
                                interviewsModel = JsonConvert.DeserializeObject<InterviewsModel>(result);
                                canditeDetailWithInterview = JsonConvert.DeserializeObject<InterviewsModel>(resultCandidateDetailListWithInterview);
                            }
                            lblCandidateFirstNameText.Text = interviewsModel.FirstName;
                            lblCandidateLastNameText.Text = interviewsModel.LastName;
                            lblCandidateAddressText.Text = interviewsModel.Address1;
                            lblCandidateEducationalQualificationText.Text = interviewsModel.QualificationName;

                        //for line item listview
                        List<InterviewsModel> interviewLineItemDetailObservableCollection = new List<InterviewsModel>();
                            interviewLineItemDetailObservableCollection = canditeDetailWithInterview.InterviewList;

                            List<Ratings> ratingListObservableCollection = new List<Ratings>();
                            foreach (var item in canditeDetailWithInterview.InterviewList)
                            {
                                for (int i = 0; i < item.RatingList.Count; i++)
                                {
                                    ratingListObservableCollection.Add(item.RatingList[i]);
                                }

                            }

                            listViewLineItemDetail.HeightRequest = 50 * ratingListObservableCollection.Count;
                            listViewLineItemDetail.ItemsSource = ratingListObservableCollection;
                            listViewLineItemDetail.ItemTemplate = new DataTemplate(() => new LineItemDetailCell(interviewLineItemDetailObservableCollection, ratingListObservableCollection));


                        //for overall listview
                        List<InterviewsModel> interviewRoundDetailObservableCollection = new List<InterviewsModel>();
                            interviewRoundDetailObservableCollection = canditeDetailWithInterview.InterviewList;



                            listView.HeightRequest = 50 * interviewRoundDetailObservableCollection.Count;

                            listView.ItemsSource = interviewRoundDetailObservableCollection;
                            listView.ItemTemplate = new DataTemplate(() => new InterviewMatrixCell(interviewRoundDetailObservableCollection, candidateListForIm, canditeDetailWithInterview));
                        });
                    }

                };
                #endregion

                #endregion

                #region listView
                sListView = new StackLayout
                {
                    Children = { listView },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                sListView.IsVisible = false;
                #endregion

                #region interview round detail
                slHeaderText = new StackLayout();
                Label lblCandidateName = new Label { Text = "Name", FontAttributes = FontAttributes.Bold, WidthRequest = 50, HorizontalOptions = LayoutOptions.StartAndExpand, TextColor = Color.FromHex("5e247f") };
                Label lblRound = new Label { Text = "Round", FontAttributes = FontAttributes.Bold, WidthRequest = 50, HorizontalOptions = LayoutOptions.StartAndExpand, TextColor = Color.FromHex("5e247f") };
                Label lblRemark = new Label { Text = "Remark", FontAttributes = FontAttributes.Bold, WidthRequest = 50, HorizontalOptions = LayoutOptions.StartAndExpand, TextColor = Color.FromHex("5e247f") };
                //Label lblAverageRating = new Label { Text = "Average Rating", FontAttributes = FontAttributes.Bold, WidthRequest = 80, HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.FromHex("5e247f") };
                //Label lblSelected = new Label { Text = "Selected", FontAttributes = FontAttributes.Bold, WidthRequest = 80, HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.FromHex("5e247f") };
                slHeaderText = new StackLayout
                {
                    Children = { lblCandidateName, lblRound, lblRemark },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                slHeaderText.IsVisible = false;

                StackLayout slCandidateInterviewInfo = new StackLayout
                {
                    Children = { sListView },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separatorListviewInterviewRounds = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                sSeparatorListviewInterviewRounds = new StackLayout
                {
                    Children = { separatorListviewInterviewRounds },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                sSeparatorListviewInterviewRounds.IsVisible = false;
                #endregion

                #region separator
                BoxView separator1 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator1 = new StackLayout
                {
                    Children = { separator1 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separator2 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator2 = new StackLayout
                {
                    Children = { separator2 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separator3 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator3 = new StackLayout
                {
                    Children = { separator3 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separator4 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator4 = new StackLayout
                {
                    Children = { separator4 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                #endregion

                #region listViewFor LineItem rating and remark


                Label lblRoundLineItem = new Label { Text = "Round", FontAttributes = FontAttributes.Bold, WidthRequest = 50, HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f"), HeightRequest = 30 };
                Label lblLineItemName = new Label { Text = "Parameter", FontAttributes = FontAttributes.Bold, WidthRequest = 70, HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f"), HeightRequest = 30 };
                Label lblRatingLineItem = new Label { Text = "Rating", FontAttributes = FontAttributes.Bold, WidthRequest = 50, HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f"), HeightRequest = 30 };
                Label lblRemarkLineItem = new Label { Text = "Remark", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f"), HeightRequest = 30 };
                Label lblSelectedLineItem = new Label { Text = "Selected", FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.End, TextColor = Color.FromHex("5e247f"), HeightRequest = 30 };
                slHeaderTextForLineItem = new StackLayout
                {
                    Children = { lblRoundLineItem, lblLineItemName, lblRatingLineItem, lblRemarkLineItem, lblSelectedLineItem },
                    Orientation = StackOrientation.Horizontal,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Padding = new Thickness(0, 20, 0, 0)
                };
                slHeaderTextForLineItem.IsVisible = false;

                spForLineItemDetail.IsVisible = false;
                sListViewLineItemDetail = new StackLayout
                {
                    Children = { listViewLineItemDetail },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                sListViewLineItemDetail.IsVisible = false;
                #endregion

                #region overall remark
                overallRemarkAdd = new CustomEntryForGeneralPurpose { Placeholder = "Add overall remark here", HorizontalOptions = LayoutOptions.FillAndExpand };
                sOverallRemarkAdd = new StackLayout
                {
                    Children = { overallRemarkAdd },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                sOverallRemarkAdd.IsVisible = false;
                spOverallRemarkAdd.IsVisible = false;
                #endregion

                #region average rating
                averageRatingAdd = new CustomEntryForGeneralPurpose { Placeholder = "Add average rating here", HorizontalOptions = LayoutOptions.FillAndExpand, Keyboard = Keyboard.Numeric };
                averageRatingAdd.Behaviors.Add(new DecimalNumberValidationBehaviour());
                sAverageRatingAdd = new StackLayout
                {
                    Children = { averageRatingAdd },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                sAverageRatingAdd.IsVisible = false;
                spAverageRatingAdd.IsVisible = false;
                #endregion

                #region seleted or not
                Label lblCandidateSelected = new Label { Text = "Selected", HorizontalOptions = LayoutOptions.StartAndExpand, TextColor = Color.Black, WidthRequest = 80 };
                Switch switchForLblCandidateSelected = new Switch { MinimumWidthRequest = 50, HorizontalOptions = LayoutOptions.StartAndExpand, BackgroundColor = Color.Transparent };
                sSwithForCandidateSelected = new StackLayout
                {
                    Children = { lblCandidateSelected, switchForLblCandidateSelected },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 0)
                };
                sSwithForCandidateSelected.IsVisible = false;
                #endregion

                #region move to next round
                Label lblCandidateMoveToNextRound = new Label { Text = "Move to next round", HorizontalOptions = LayoutOptions.StartAndExpand, TextColor = Color.Black, WidthRequest = 80 };
                Switch switchForLblCandidateMoveToNextRound = new Switch { MinimumWidthRequest = 50, HorizontalOptions = LayoutOptions.StartAndExpand, BackgroundColor = Color.Transparent };
                sSwithForCandidateMoveToNextRound = new StackLayout
                {
                    Children = { lblCandidateMoveToNextRound, switchForLblCandidateMoveToNextRound },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 10)
                };
                sSwithForCandidateMoveToNextRound.IsVisible = false;
                #endregion

                #region save button for saving all information
                Label AfterSaveResponseAllInformation = new Label { Text = "", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Green };
                slAfterSaveResponseAllInformation = new StackLayout
                {
                    Children = { AfterSaveResponseAllInformation },
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(0, 8, 0, 0)
                };
                slAfterSaveResponseAllInformation.IsVisible = false;

                Button btnSaveAllInfo = new Button { Text = "Save", HorizontalOptions = LayoutOptions.CenterAndExpand, BackgroundColor = Color.FromHex("f7cc59"), TextColor = Color.Black, BorderRadius = 50, WidthRequest = 200, FontAttributes = FontAttributes.Bold };
                sbtnSaveAllInfo = new StackLayout
                {
                    Children = { btnSaveAllInfo },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 8)
                };
                sbtnSaveAllInfo.IsVisible = false;



                #endregion

                #region post data
                btnSaveAllInfo.Clicked += (object sender, EventArgs e) =>
                {
                    if (ValidateForAllDataSave())
                    {
                        interviewsModel.IRRemarks = overallRemarkAdd.Text;
                        interviewsModel.IRCombinedRating = decimal.Parse(averageRatingAdd.Text);
                        if (switchForLblCandidateSelected.IsToggled == true)
                        {
                            interviewsModel.IRSelected = 1;
                        }
                        if (switchForLblCandidateSelected.IsToggled == false)
                        {
                            interviewsModel.IRSelected = 0;
                        }
                        if (switchForLblCandidateMoveToNextRound.IsToggled == true)
                        {
                            interviewsModel.IRMovedToNextRound = 1;
                        }
                        if (switchForLblCandidateMoveToNextRound.IsToggled == false)
                        {
                            interviewsModel.IRMovedToNextRound = 0;
                        }
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            var result = await Service.SaveInterviewRound(interviewsModel);
                            AfterSaveResponseAllInformation.Text = "Data saved";
                        });
                        lineItemAdd.Text = string.Empty;
                    }

                };
                #endregion

                #region line item save
                lineItemAdd = new CustomEntryForGeneralPurpose { Placeholder = "Add new line item here", HorizontalOptions = LayoutOptions.FillAndExpand };
                slineItemAdd = new StackLayout
                {
                    Children = { lineItemAdd },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                slineItemAdd.IsVisible = false;
                spLineItemAdd.IsVisible = false;

                Label AfterSaveResponseLineItem = new Label { Text = "", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Green };
                slAfterSaveResponseLineItem = new StackLayout
                {
                    Children = { AfterSaveResponseLineItem },
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(0, 8, 0, 0)
                };
                slAfterSaveResponseLineItem.IsVisible = false;

                Button btnSaveDataLineItem = new Button { Text = "Add Line Item", HorizontalOptions = LayoutOptions.CenterAndExpand, BackgroundColor = Color.FromHex("f7cc59"), TextColor = Color.Black, BorderRadius = 50, WidthRequest = 200, FontAttributes = FontAttributes.Bold };
                sbtnSaveDataLineItem = new StackLayout
                {
                    Children = { btnSaveDataLineItem },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 8)
                };
                sbtnSaveDataLineItem.IsVisible = false;
                LineItem lineItems = new LineItem();

                btnSaveDataLineItem.Clicked += (object sender, EventArgs e) =>
                {
                    if (ValidateForLineItem())
                    {

                        lineItems.LineItemDescription = lineItemAdd.Text;
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            var result = await Service.PostLineItem(lineItems);
                            AfterSaveResponseLineItem.Text = "Line item saved";
                        });
                        lineItemAdd.Text = string.Empty;
                    }

                };
                #endregion

                #region contents and stack layouts

                StackLayout slInterviewMatrixInformation = new StackLayout
                {
                    Children = { sInterviewMatrixInfo,

                    frmPkrCandidateName,candidateNameSeparator,
                sBtnSubmitCandidate,
                slCandidateInformation,

                    sInterviewRoundEdit , slCandidateEditInfo,
                    slHeaderTextForLineItem, spForLineItemDetail, sListViewLineItemDetail,
                    slHeaderText, sSeparatorListviewInterviewRounds, slCandidateInterviewInfo,
                    sOverallRemarkAdd, spOverallRemarkAdd, sAverageRatingAdd, spAverageRatingAdd, sSwithForCandidateSelected,sSwithForCandidateMoveToNextRound,
                    slAfterSaveResponseAllInformation, sbtnSaveAllInfo,
                    slineItemAdd ,spLineItemAdd, slAfterSaveResponseLineItem, sbtnSaveDataLineItem },
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Padding = new Thickness(20, 0, 20, 0),
                    BackgroundColor = Color.White
                };

                ScrollView svInterviewMatrixDetails = new ScrollView { Content = slInterviewMatrixInformation };

                Content = svInterviewMatrixDetails;

                #endregion
            }
            else
            {
                Navigation.PushModalAsync(new Login());
            }
        }

        #region validation
        private bool Validate()
        {
            if (pkrCandidateName.SelectedIndex == -1)
            {
                DisplayAlert("Error", "Please select a value for Candidate Name", "OK");
                return false;
            }
            return true;
        }

        private bool ValidateForLineItem()
        {
            if (string.IsNullOrEmpty(lineItemAdd.Text))
            {
                DisplayAlert("Error", "Please enter a value for Line Item", "OK");
                return false;
            }
            return true;
        }

        private bool ValidateForAllDataSave()
        {
            if (string.IsNullOrEmpty(overallRemarkAdd.Text))
            {
                DisplayAlert("Error", "Please enter a value for remark", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(averageRatingAdd.Text))
            {
                DisplayAlert("Error", "Please enter a value for rating", "OK");
                return false;
            }
            if (averageRatingAdd.TextColor == Color.Red)
            {
                DisplayAlert("Error", "Please enter valid value for rating", "OK");
                return false;
            }
            return true;
        }
        #endregion
    }



}
