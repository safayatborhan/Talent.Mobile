using ImageCircle.Forms.Plugin.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Context;
using Talent.Mobile.Controls;
using Talent.Mobile.CustomRenderer;
using Talent.Mobile.Models;
using Talent.Mobile.Models.College;
using Talent.Mobile.Models.InterviewModels;
using Talent.Mobile.Models.Models;
using Talent.Mobile.Models.University;
using Xamarin.Forms;

namespace Talent.Mobile.Pages.User
{
    class InterviewDetails : BasePage
    {
        #region initialize
        private List<CustomEntryForLogin> ratingEntry = new List<CustomEntryForLogin>();
        private List<CustomEntryForLogin> remarkEntry = new List<CustomEntryForLogin>();
        private List<List<CustomEntryForLogin>> pp = new List<List<CustomEntryForLogin>>();

        Picker pkrCandidateName = new Picker();
        TapGestureRecognizer recognizerCandidateName = new TapGestureRecognizer();
        StackLayout slCandidateInformation = new StackLayout();
        InterviewsModel interviewsModel = new InterviewsModel();
        CustomEntryForGeneralPurpose txtRating = new CustomEntryForGeneralPurpose();
        CustomEntryForGeneralPurpose txtRemark = new CustomEntryForGeneralPurpose();
        #endregion

        #region constructor
        public InterviewDetails()
        {
            try
            {
                List<CandidateDetails> candidate = new List<CandidateDetails>();
                Candidate candidate2 = new Candidate();
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var resultCandidate = await Service.GetCandidate(ACTContext.interviewerId);  //passing interviewer id 
                    var resultCandidate2 = "[" + resultCandidate + "]";
                    if (resultCandidate != null)
                    {
                        candidate = (List<CandidateDetails>)JsonConvert.DeserializeObject<List<CandidateDetails>>(resultCandidate);
                        InterviewDetailsLayout(candidate,candidate2);
                    }

                });
            }
            catch(Exception ex)
            {

            }
            
        }
        #endregion


        public void InterviewDetailsLayout(List<CandidateDetails> candidate, Candidate candidate2)
        {
            if (ACTContext.isLogin == true)
            {
                #region Header text
                Label lblInterviewDetailsInfo = new Label { Text = "Interview Details Information", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.FromHex("5e247f"), FontSize = 18, FontAttributes = FontAttributes.Bold, HeightRequest = 30 };
                Label interviewDetailsInfo = new Label { Text = "", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, HeightRequest = 40 };
                StackLayout sInterviewDetailInfo = new StackLayout
                {
                    Children = { lblInterviewDetailsInfo, interviewDetailsInfo },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 30, 0, 0)
                };
                #endregion

                #region candidate name
                Label lblCandidatePickerTitle = new Label { Text = "Candidate Name", TextColor = Color.Gray };
                pkrCandidateName = new Picker { IsVisible = false };
                pkrCandidateName.Title = "Candidate Name";
                foreach (CandidateDetails item in candidate)
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

                recognizerCandidateName.NumberOfTapsRequired = 1; // single-tap
                recognizerCandidateName.Tapped += (s, e) =>
                {
                    pkrCandidateName.Focus();
                };
                frmPkrCandidateName.GestureRecognizers.Add(recognizerCandidateName);
                Seperator candidateNameSeparator = new Seperator();

                //Button for submit candidate name and fetch particular data regarding the candidate
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

                #region listview for line items
                Label lblListViewHeader = new Label { Text = "Give parameter wise rating and remark", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.FromHex("5e247f"), FontSize = 14, FontAttributes = FontAttributes.Bold };
                StackLayout slblListViewHeader = new StackLayout
                {
                    Children = { lblListViewHeader },
                    Padding = new Thickness(0, 10, 0, 10)
                };

                List<LineItem> lineItemObservableCollection = new List<LineItem>();
                lineItemObservableCollection = interviewsModel.LineItemList;
                ListView listView = new ListView();

                listView.SeparatorColor = Color.Gray;
                listView.HeightRequest = 50 * interviewsModel.LineItemList.Count;
                StackLayout sListView = new StackLayout
                {
                    Children = { listView },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 10)
                };
                #endregion

                #region overall remark
                txtRemark = new CustomEntryForGeneralPurpose { Placeholder = "Overall Remark", HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sRemark = new StackLayout
                {
                    Children = { txtRemark },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                Seperator seperatorRemark = new Seperator();
                #endregion

                #region seleted or not
                Label lblCandidateSelected = new Label { Text = "Selected", HorizontalOptions = LayoutOptions.StartAndExpand, TextColor = Color.Black, WidthRequest = 80 };
                Switch switchForLblCandidateSelected = new Switch { MinimumWidthRequest = 50, HorizontalOptions = LayoutOptions.StartAndExpand, BackgroundColor = Color.Transparent };
                StackLayout sSwithForCandidateSelected = new StackLayout
                {
                    Children = { lblCandidateSelected, switchForLblCandidateSelected },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 10)
                };
                #endregion

                #region after response
                Label AfterSaveResponse = new Label { Text = "", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Green };
                StackLayout slAfterSaveResponse = new StackLayout
                {
                    Children = { AfterSaveResponse },
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(0, 8, 0, 0)
                };
                #endregion

                #region save button
                Button btnSaveData = new Button { Text = "SAVE", HorizontalOptions = LayoutOptions.CenterAndExpand, BackgroundColor = Color.FromHex("f7cc59"), TextColor = Color.Black, BorderRadius = 50, WidthRequest = 270, FontAttributes = FontAttributes.Bold };
                StackLayout sbtnSaveData = new StackLayout
                {
                    Children = { btnSaveData },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 8)
                };
                #endregion

                #region candidate information stack layout
                slCandidateInformation = new StackLayout
                {
                    Children = { slblCandidateFirstName,separatorFirstName,
                    slblCandidateLastName, separatorLastName,
                    slblCandidateAddress, separatorAddress,
                    slblCandidateEducationalQualification, separatorEducationalQualification,
                    slblListViewHeader, sListView,
                    sRemark,seperatorRemark,
                    sSwithForCandidateSelected,
                    slAfterSaveResponse, sbtnSaveData}
                };
                slCandidateInformation.IsVisible = false;
                #endregion

                #region submit button click
                btnSubmitCandidate.Clicked += (object sender, EventArgs e) =>
                {
                    if (Validate())
                    {
                        slCandidateInformation.IsVisible = true;
                        int interviewId = (from c in candidate where c.CandidateName == pkrCandidateName.Items[pkrCandidateName.SelectedIndex] select c.InterviewId).SingleOrDefault();
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            var result = await Service.GetCandidateInformation(interviewId, ACTContext.interviewerId);
                            if (result != null)
                            {
                                interviewsModel = JsonConvert.DeserializeObject<InterviewsModel>(result);
                            }
                            lblCandidateFirstNameText.Text = interviewsModel.FirstName;
                            lblCandidateLastNameText.Text = interviewsModel.LastName;
                            lblCandidateAddressText.Text = interviewsModel.Address1;
                            lblCandidateEducationalQualificationText.Text = interviewsModel.QualificationName;
                            lineItemObservableCollection = interviewsModel.LineItemList;

                            listView.HeightRequest = 50 * interviewsModel.LineItemList.Count;

                            listView.ItemsSource = lineItemObservableCollection;
                            listView.ItemTemplate = new DataTemplate(() => new LineItemCell(lineItemObservableCollection));
                        });
                    }

                };
                #endregion
                #endregion

                #region stack layouts and contents
                StackLayout slUserDetailsInformation = new StackLayout
                {
                    Children = { sInterviewDetailInfo, frmPkrCandidateName,candidateNameSeparator,
                sBtnSubmitCandidate,
                slCandidateInformation },
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Padding = new Thickness(20, 0, 20, 30),
                    BackgroundColor = Color.White
                };

                ScrollView svUserDetails = new ScrollView { Content = slUserDetailsInformation };

                Content = svUserDetails;

                Interview interview = new Interview();
                #endregion

                #region post data
                btnSaveData.Clicked += (object sender, EventArgs e) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        int interviewId2 = (from c in candidate where c.CandidateName == pkrCandidateName.Items[pkrCandidateName.SelectedIndex] select c.InterviewId).SingleOrDefault();
                        var resultForPostData = await Service.GetCandidateInformation(interviewId2, ACTContext.interviewerId);
                        if (resultForPostData != null)
                        {
                            interviewsModel = JsonConvert.DeserializeObject<InterviewsModel>(resultForPostData);
                        }
                        interviewsModel.OvarAllRemarks = txtRemark.Text;
                        for (int i = 0; i < ACTContext.ratingDetailsListContext.Count; i++)
                        {
                            interviewsModel.RatingList.Add(ACTContext.ratingDetailsListContext[i]);

                        }

                        if (switchForLblCandidateSelected.IsToggled == true)
                        {
                            interviewsModel.IsSelected = 1;
                        }
                        if (switchForLblCandidateSelected.IsToggled == false)
                        {
                            interviewsModel.IsSelected = 0;
                        }
                        var resultAfterPostData = await Service.PostInterviewDetails(interviewsModel);
                        AfterSaveResponse.Text = "Data saved successfully";
                        txtRemark.Text = string.Empty;
                        interviewsModel.RatingList.Clear();
                        ACTContext.ratingDetailsListContext.Clear();

                        lineItemObservableCollection = interviewsModel.LineItemList;

                        listView.ItemsSource = lineItemObservableCollection;
                        listView.ItemTemplate = new DataTemplate(() => new LineItemCell(lineItemObservableCollection));
                    });
                };
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
        #endregion
    }
}
