using DevenvExeBehaviors;
using ImageCircle.Forms.Plugin.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
using Talent.Mobile.Models.University;
using Xamarin.Forms;

namespace Talent.Mobile.Pages.User
{
    class EducationDetails : BasePage
    {
        #region constructor
        public EducationDetails()
        {
            List<Education> educationList = new List<Education>();
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await Service.GetEducationDetails(ACTContext.userId);

                if (result != null)
                {
                    educationList = (List<Education>)JsonConvert.DeserializeObject<List<Education>>(result);
                }
            });
            
            List<College> college = new List<College>();
            List<UniversityModel> university = new List<UniversityModel>();
            List<Qualification> pkrQualification = new List<Qualification>();
            List<Degree> pkrDegree = new List<Degree>();
            List<Streams> streamList = new List<Streams>();
            Device.BeginInvokeOnMainThread(async () =>
            {
                var resultUniversity = await Service.GetUniversities();

                var resultCollege = await Service.GetColleges();

                var resultQualification = await Service.GetQualifications();

                var resultDegree = await Service.GetDegrees();

                var resultStreams = await Service.GetStreams();

                if (resultUniversity != null && resultCollege != null && resultQualification != null && resultDegree != null)
                {
                    college = (List<College>)JsonConvert.DeserializeObject<List<College>>(resultCollege);
                    university = (List<UniversityModel>)JsonConvert.DeserializeObject<List<UniversityModel>>(resultUniversity);
                    pkrQualification = (List<Qualification>)JsonConvert.DeserializeObject<List<Qualification>>(resultQualification);
                    pkrDegree = (List<Degree>)JsonConvert.DeserializeObject<List<Degree>>(resultDegree);
                    streamList = (List<Streams>)JsonConvert.DeserializeObject<List<Streams>>(resultStreams);
                    EducationDetailsLayout(college,university,pkrQualification,pkrDegree, educationList,streamList);
                }

            });
            
        }
        #endregion

        #region initialize
        Picker pkrUniversityName = new Picker();
        Picker pkrCollegeName = new Picker();
        Picker pkrQualification = new Picker();
        Picker pkrDegree = new Picker();
        Picker pkrBranch = new Picker();

        Label lblFromDateText = new Label();
        Label lblToDateText = new Label();
        

        CustomEntryForGeneralPurpose txtPercentage = new CustomRenderer.CustomEntryForGeneralPurpose();
        CustomEntryForGeneralPurpose txtProjectInformation = new CustomRenderer.CustomEntryForGeneralPurpose();

        //CustomEntryForGeneralPurpose txtBranch = new CustomEntryForGeneralPurpose();

        TapGestureRecognizer recognizerUniversityName = new TapGestureRecognizer();
        TapGestureRecognizer recognizerCollegeName = new TapGestureRecognizer();
        TapGestureRecognizer recognizerQualification = new TapGestureRecognizer();
        TapGestureRecognizer recognizerDegree = new TapGestureRecognizer();
        TapGestureRecognizer recognizerBranch = new TapGestureRecognizer();

        List<Education> educationObservableCollection = new List<Education>();
        ListView listView = new ListView();

        StackLayout slEducationAllInformationAdd = new StackLayout();
        #endregion

        public void EducationDetailsLayout(List<College> college, List<UniversityModel> university, List<Qualification> qualifications, List<Degree> degrees, List<Education> educationList, List<Streams> streamList)
        {
            if (ACTContext.isLogin == true)
            {
                #region add education detail button
                Button btnAddNewWorkExp = new Button { Text = "Add education detail", HorizontalOptions = LayoutOptions.EndAndExpand, BackgroundColor = Color.FromHex("4690FB"), TextColor = Color.White, BorderRadius = 10, HeightRequest = 35, FontSize = 10, FontAttributes = FontAttributes.Bold };
                StackLayout sBtnAddNewWorkExp = new StackLayout
                {
                    Children = { btnAddNewWorkExp },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(2, 5, 2, 5)
                };
                #endregion

                #region university, college, pkrQualification, pkrDegree pickers
                Label lblEducationDetailsInfo = new Label { Text = "Education Details Information", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.FromHex("5e247f"), FontSize = 18, FontAttributes = FontAttributes.Bold, HeightRequest = 30 };
                StackLayout sEducationDetailInfo = new StackLayout
                {
                    Children = { lblEducationDetailsInfo },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 50, 0, 10)
                };
                Seperator sListViewHeader = new Seperator();
                #region university name
                Label lblUniversityPickerTitle = new Label { Text = "University Name", TextColor = Color.Gray };
                pkrUniversityName = new Picker { IsVisible = false };
                pkrUniversityName.Title = "University Name";
                foreach (UniversityModel item in university)
                {
                    pkrUniversityName.Items.Add(item.UniversityName);
                }
                pkrUniversityName.SelectedIndexChanged += (s, e) =>
                {
                    lblUniversityPickerTitle.TextColor = Color.Black;
                    lblUniversityPickerTitle.Text = pkrUniversityName.Items[pkrUniversityName.SelectedIndex].ToString();
                };
                Image imgpkrUniversityNameDropdown = new Image { Source = "dropdownPicker.png", HorizontalOptions = LayoutOptions.EndAndExpand };

                StackLayout spkrUniversityName = new StackLayout { Children = { lblUniversityPickerTitle, pkrUniversityName, imgpkrUniversityNameDropdown }, Orientation = StackOrientation.Horizontal, Padding = new Thickness(0, 5, 0, 5) };
                Frame frmpkrUniversityName = new Frame { Content = spkrUniversityName, BackgroundColor = Color.White, Padding = new Thickness(Device.OnPlatform(8, 5, 0)), HasShadow = false };

                recognizerUniversityName.NumberOfTapsRequired = 1; // single-tap
                recognizerUniversityName.Tapped += (s, e) =>
                {
                    pkrUniversityName.Focus();
                };
                frmpkrUniversityName.GestureRecognizers.Add(recognizerUniversityName);
                Seperator universityNameSeparator = new Seperator();
                #endregion

                #region college name
                Label lblCollegePickerTitle = new Label { Text = "College Name", TextColor = Color.Gray };
                pkrCollegeName = new Picker { IsVisible = false };
                pkrCollegeName.Title = "College Name";
                foreach (College item in college)
                {
                    pkrCollegeName.Items.Add(item.CollegeName);
                }
                pkrCollegeName.SelectedIndexChanged += (s, e) =>
                {
                    lblCollegePickerTitle.TextColor = Color.Black;
                    lblCollegePickerTitle.Text = pkrCollegeName.Items[pkrCollegeName.SelectedIndex].ToString();
                };
                Image imgCollegeNameDropdown = new Image { Source = "dropdownPicker.png", HorizontalOptions = LayoutOptions.EndAndExpand };

                StackLayout sCollegeName = new StackLayout { Children = { lblCollegePickerTitle, pkrCollegeName, imgCollegeNameDropdown }, Orientation = StackOrientation.Horizontal, Padding = new Thickness(0, 5, 0, 5) };
                Frame frmCollegeName = new Frame { Content = sCollegeName, BackgroundColor = Color.White, Padding = new Thickness(Device.OnPlatform(8, 5, 0)), HasShadow = false };

                recognizerCollegeName.NumberOfTapsRequired = 1; // single-tap
                recognizerCollegeName.Tapped += (s, e) =>
                {
                    pkrCollegeName.Focus();
                };
                frmCollegeName.GestureRecognizers.Add(recognizerCollegeName);
                Seperator collegeNameSeparator = new Seperator();
                #endregion

                #region qualification
                Label lblQualificationPickerTitle = new Label { Text = "Qualification", TextColor = Color.Gray, FontSize = Device.OnPlatform(11, 14, 14) };
                pkrQualification = new Picker { IsVisible = false };
                pkrQualification.Title = "Qualification";
                foreach (Qualification item in qualifications)
                {
                    pkrQualification.Items.Add(item.QualificationName);
                }
                pkrQualification.SelectedIndexChanged += (s, e) =>
                {
                    lblQualificationPickerTitle.TextColor = Color.Black;
                    lblQualificationPickerTitle.Text = pkrQualification.Items[pkrQualification.SelectedIndex].ToString();
                };
                Image imgQualificationDropdown = new Image { Source = "dropdownPicker.png", HorizontalOptions = LayoutOptions.EndAndExpand };

                StackLayout sQualificationName = new StackLayout { Children = { lblQualificationPickerTitle, pkrQualification, imgQualificationDropdown }, Orientation = StackOrientation.Horizontal, Padding = new Thickness(0, 5, 0, 5) };
                Frame frmQualification = new Frame { Content = sQualificationName, BackgroundColor = Color.White, Padding = new Thickness(Device.OnPlatform(8, 5, 0)), HasShadow = false };

                recognizerQualification.NumberOfTapsRequired = 1; // single-tap
                recognizerQualification.Tapped += (s, e) =>
                {
                    pkrQualification.Focus();
                };
                frmQualification.GestureRecognizers.Add(recognizerQualification);
                Seperator qualificationSeparator = new Seperator();
                #endregion

                #region degree
                Label lblDegreePickerTitle = new Label { Text = "Degree", TextColor = Color.Gray };
                pkrDegree = new Picker { IsVisible = false };
                pkrDegree.Title = "Degree";
                foreach (Degree item in degrees)
                {
                    pkrDegree.Items.Add(item.DegreeName);
                }
                pkrDegree.SelectedIndexChanged += (s, e) =>
                {
                    lblDegreePickerTitle.TextColor = Color.Black;
                    lblDegreePickerTitle.Text = pkrDegree.Items[pkrDegree.SelectedIndex].ToString();
                };
                Image imgDegreeDropdown = new Image { Source = "dropdownPicker.png", HorizontalOptions = LayoutOptions.EndAndExpand };

                StackLayout sDegreeName = new StackLayout { Children = { lblDegreePickerTitle, pkrDegree, imgDegreeDropdown }, Orientation = StackOrientation.Horizontal, Padding = new Thickness(0, 5, 0, 5) };
                Frame frmDegree = new Frame { Content = sDegreeName, BackgroundColor = Color.White, Padding = new Thickness(Device.OnPlatform(8, 5, 0)), HasShadow = false };

                recognizerDegree.NumberOfTapsRequired = 1; // single-tap
                recognizerDegree.Tapped += (s, e) =>
                {
                    pkrDegree.Focus();
                };
                frmDegree.GestureRecognizers.Add(recognizerDegree);
                Seperator degreeSeparator = new Seperator();
                #endregion

                #endregion

                #region branch
                Label lblBranchPickerTitle = new Label { Text = "Branch", TextColor = Color.Gray };
                pkrBranch = new Picker { IsVisible = false };
                pkrBranch.Title = "Branch";
                foreach (Streams item in streamList)
                {
                    pkrBranch.Items.Add(item.StreamName);
                }
                pkrBranch.SelectedIndexChanged += (s, e) =>
                {
                    lblBranchPickerTitle.TextColor = Color.Black;
                    lblBranchPickerTitle.Text = pkrBranch.Items[pkrBranch.SelectedIndex].ToString();
                };
                Image imgBranchDropdown = new Image { Source = "dropdownPicker.png", HorizontalOptions = LayoutOptions.EndAndExpand };

                StackLayout sBranchName = new StackLayout { Children = { lblBranchPickerTitle, pkrBranch, imgBranchDropdown }, Orientation = StackOrientation.Horizontal, Padding = new Thickness(0, 5, 0, 5) };
                Frame frmBranch = new Frame { Content = sBranchName, BackgroundColor = Color.White, Padding = new Thickness(Device.OnPlatform(8, 5, 0)), HasShadow = false };

                recognizerBranch.NumberOfTapsRequired = 1;
                recognizerBranch.Tapped += (s, e) =>
                {
                    pkrBranch.Focus();
                };
                frmBranch.GestureRecognizers.Add(recognizerBranch);

                //txtBranch = new CustomEntryForGeneralPurpose { Placeholder = "Branch", HorizontalOptions = LayoutOptions.FillAndExpand };

                //StackLayout sBranch = new StackLayout
                //{
                //    Children = { txtBranch },
                //    Orientation = StackOrientation.Horizontal,
                //    Padding = new Thickness(0, 0, 0, 0)
                //};
                Seperator seperatorBranch = new Seperator();
                #endregion

                #region duration
                Label lblDuration = new Label { Text = "Duration", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Gray, WidthRequest = 80, HeightRequest = 30 };
                StackLayout slblDuration = new StackLayout
                {
                    Children = { lblDuration },
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.End,
                    Margin = new Thickness(3, 8, 0, 0)
                };

                lblFromDateText = new Label { Text = "From", HorizontalOptions = LayoutOptions.Center, TextColor = Color.Gray };

                StackLayout sLblFromDateText = new StackLayout
                {
                    Children = { lblFromDateText },
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(0, 8, 0, 0)
                };

                Image imgFromDateArrow = new Image { Source = "calendar.png", HorizontalOptions = LayoutOptions.End };

                StackLayout slFromDateTap = new StackLayout { Children = { sLblFromDateText, imgFromDateArrow }, Orientation = StackOrientation.Horizontal };

                DatePicker dtFromDate = new DatePicker { IsVisible = false, BackgroundColor = Color.White };
                var fromDateTapGestureRecognizer = new TapGestureRecognizer();

                fromDateTapGestureRecognizer.NumberOfTapsRequired = 1; // single-tap
                fromDateTapGestureRecognizer.Tapped += (s, e) =>
                {
                    dtFromDate.Focus();
                };

                slFromDateTap.GestureRecognizers.Add(fromDateTapGestureRecognizer);

                dtFromDate.DateSelected += (object sender, DateChangedEventArgs e) =>
                {
                    //lblFromDateText.Text = e.NewDate.ToString("dd-MM-yyyy");
                    lblFromDateText.Text = e.NewDate.ToString("yyyy-MM-dd");
                };

                //To date
                lblToDateText = new Label { Text = "To", HorizontalOptions = LayoutOptions.Center, TextColor = Color.Gray };

                StackLayout sLblToDateText = new StackLayout
                {
                    Children = { lblToDateText },
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(0, 8, 0, 0)
                };

                Image imgToDateArrow = new Image { Source = "calendar.png", HorizontalOptions = LayoutOptions.End };

                StackLayout slToDateTap = new StackLayout { Children = { sLblToDateText, imgToDateArrow }, Orientation = StackOrientation.Horizontal };

                DatePicker dtToDate = new DatePicker { IsVisible = false, BackgroundColor = Color.White };
                var toDateTapGestureRecognizer = new TapGestureRecognizer();

                toDateTapGestureRecognizer.NumberOfTapsRequired = 1; // single-tap
                toDateTapGestureRecognizer.Tapped += (s, e) =>
                {
                    dtToDate.Focus();
                };

                slToDateTap.GestureRecognizers.Add(toDateTapGestureRecognizer);

                dtToDate.DateSelected += (object sender, DateChangedEventArgs e) =>
                {
                    //lblToDateText.Text = e.NewDate.ToString("dd-MM-yyyy");
                    lblToDateText.Text = e.NewDate.ToString("yyyy-MM-dd");
                };

                Label lblFromToTo = new Label { Text = "-", HorizontalOptions = LayoutOptions.Center, TextColor = Color.Gray };

                StackLayout sLblFromToTo = new StackLayout
                {
                    Children = { lblFromToTo },
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(0, 8, 0, 0)
                };

                StackLayout sWorkDuration = new StackLayout
                {
                    Children = { slblDuration, slFromDateTap, dtFromDate, sLblFromToTo, slToDateTap, dtToDate },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                Seperator sDuration = new Seperator();
                #endregion

                #region percentage, project info, aftersave response, button
                txtPercentage = new CustomEntryForGeneralPurpose { Placeholder = "Percentage", HorizontalOptions = LayoutOptions.FillAndExpand, Keyboard = Keyboard.Numeric };
                txtPercentage.Behaviors.Add(new DecimalNumberValidationBehaviour());
                StackLayout sPercentage = new StackLayout
                {
                    Children = { txtPercentage },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                Seperator sPercentageText = new Seperator();
                txtProjectInformation = new CustomEntryForGeneralPurpose { Placeholder = "Project Information", HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sProjectInformation = new StackLayout
                {
                    Children = { txtProjectInformation },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                Seperator sProjectInfo = new Seperator();
                Label AfterSaveResponse = new Label { Text = "", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Green };
                StackLayout slAfterSaveResponse = new StackLayout
                {
                    Children = { AfterSaveResponse },
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(0, 8, 0, 0)
                };

                Button btnSaveData = new Button { Text = "SAVE", HorizontalOptions = LayoutOptions.CenterAndExpand, BackgroundColor = Color.FromHex("f7cc59"), TextColor = Color.Black, BorderRadius = 50, WidthRequest = 270, FontAttributes = FontAttributes.Bold };
                StackLayout sbtnSaveData = new StackLayout
                {
                    Children = { btnSaveData },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 8)
                };
                #endregion

                #region listView

                Label lblAddNewEducationDetail = new Label { Text = "Add new education detail information here", HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f"), FontSize = 14, FontAttributes = FontAttributes.Bold };
                StackLayout slblAddNewEducationDetail = new StackLayout
                {
                    Children = { lblAddNewEducationDetail },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 20, 0, 0)
                };

                StackLayout slHeaderText = new StackLayout();
                Label lblColege = new Label { Text = "College", FontAttributes = FontAttributes.Bold, WidthRequest = 130, HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f") };
                Label lblpkrDegree = new Label { Text = "Degree", FontAttributes = FontAttributes.Bold, WidthRequest = 130, HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f") };
                Label lblPercentage = new Label { Text = "Percentage", FontAttributes = FontAttributes.Bold, WidthRequest = 130, HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f") };
                Label lblEmpty = new Label { Text = "", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black };
                slHeaderText = new StackLayout
                {
                    Children = { lblColege, lblpkrDegree, lblPercentage, lblEmpty },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                if(educationList.Count == 0)
                {
                    slHeaderText.IsVisible = false;
                    sListViewHeader.IsVisible = false;
                }


                educationObservableCollection = educationList;

                listView.ItemsSource = educationObservableCollection;
                listView.ItemTemplate = new DataTemplate(() => new EducationCell(educationObservableCollection, college, qualifications));
                listView.HeightRequest = 50 * educationList.Count;
                StackLayout sListView = new StackLayout
                {
                    Children = { listView },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };

                #endregion

                #region stack layout, scroll view and content

                slEducationAllInformationAdd = new StackLayout
                {
                    Children = {slblAddNewEducationDetail,
                    frmpkrUniversityName, universityNameSeparator, frmCollegeName, collegeNameSeparator,
                    frmQualification, qualificationSeparator,
                    frmDegree, degreeSeparator, frmBranch, seperatorBranch,
                    sWorkDuration, sDuration, sPercentage, sPercentageText,
                        sProjectInformation, sProjectInfo, slAfterSaveResponse, sbtnSaveData }
                };
                slEducationAllInformationAdd.IsVisible = false;
                btnAddNewWorkExp.Clicked += (object sender, EventArgs e) =>
                {
                    slEducationAllInformationAdd.IsVisible = true;
                };

                StackLayout slEducationDetailsInformation = new StackLayout
                {
                    Children = { sBtnAddNewWorkExp, sEducationDetailInfo, slHeaderText, sListViewHeader, sListView, slEducationAllInformationAdd },
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Padding = new Thickness(20, 0, 20, 30),
                    BackgroundColor = Color.White
                };

                ScrollView svEducationDetails = new ScrollView { Content = slEducationDetailsInformation };

                Content = svEducationDetails;
                #endregion

                #region posting data
                Education education = new Education();

                btnSaveData.Clicked += (object sender, EventArgs e) =>
                {
                    if (Validate())
                    {
                        if (DateTime.Parse(lblFromDateText.Text) > DateTime.Parse(lblToDateText.Text))
                        {
                            DisplayAlert("Error", "Start date can not be greater than end date.", "OK");
                        }
                        else
                        {
                            education.UserId = ACTContext.userId;
                            education.CollegeId = (from c in college where c.CollegeName == pkrCollegeName.Items[pkrCollegeName.SelectedIndex] select c.Id).SingleOrDefault();
                            education.BranchId = (from d in streamList where d.StreamName == pkrBranch.Items[pkrBranch.SelectedIndex] select d.StreamID).SingleOrDefault();
                            education.DegreeId = (from d in degrees where d.DegreeName == pkrDegree.Items[pkrDegree.SelectedIndex] select d.Id).SingleOrDefault();
                            education.QualificationId = (from q in qualifications where q.QualificationName == pkrQualification.Items[pkrQualification.SelectedIndex] select q.Id).SingleOrDefault();
                            education.FromDate = DateTime.Parse(lblFromDateText.Text);
                            education.ToDate = DateTime.Parse(lblToDateText.Text);
                            education.Percentage = decimal.Parse(txtPercentage.Text);
                            education.ProjectInfo = txtProjectInformation.Text;

                            slHeaderText.IsVisible = true;
                            sListViewHeader.IsVisible = true;

                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                var result = await Service.PostEducationDetail(education);
                                AfterSaveResponse.Text = "Data saved";
                                txtPercentage.Text = string.Empty;
                                txtProjectInformation.Text = string.Empty;

                                lblUniversityPickerTitle.Text = "University";
                                lblUniversityPickerTitle.TextColor = Color.Gray;
                                pkrUniversityName.IsVisible = false;

                                lblCollegePickerTitle.Text = "College";
                                lblCollegePickerTitle.TextColor = Color.Gray;
                                pkrCollegeName.IsVisible = false;

                                lblQualificationPickerTitle.Text = "Qualification";
                                lblQualificationPickerTitle.TextColor = Color.Gray;
                                pkrQualification.IsVisible = false;

                                lblDegreePickerTitle.Text = "Degree";
                                lblDegreePickerTitle.TextColor = Color.Gray;
                                pkrDegree.IsVisible = false;

                                lblBranchPickerTitle.Text = "Branch";
                                lblBranchPickerTitle.TextColor = Color.Gray;
                                pkrBranch.IsVisible = false;

                                var resultUpdated = await Service.GetEducationDetails(ACTContext.userId);
                                if (resultUpdated != null)
                                {
                                    educationList = (List<Education>)JsonConvert.DeserializeObject<List<Education>>(resultUpdated);
                                }
                                educationObservableCollection = educationList;
                                listView.ItemsSource = educationObservableCollection;
                                listView.HeightRequest = 50 * educationList.Count;
                                listView.ItemTemplate = new DataTemplate(() => new EducationCell(educationObservableCollection, college, qualifications));
                            });
                        }
                        
                    };

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
            if (pkrUniversityName.SelectedIndex == -1)
            {
                DisplayAlert("Error", "Please select a value for University Name", "OK");
                return false;
            }
            if (pkrCollegeName.SelectedIndex == -1)
            {
                DisplayAlert("Error", "Please select a value for College Name", "OK");
                return false;
            }
            if (pkrQualification.SelectedIndex == -1)
            {
                DisplayAlert("Error", "Please select a value for Qualificaiton", "OK");
                return false;
            }
            if (pkrDegree.SelectedIndex == -1)
            {
                DisplayAlert("Error", "Please select a value for Degree", "OK");
                return false;
            }
            if (pkrBranch.SelectedIndex == -1)
            {
                DisplayAlert("Error", "Please select a value for Branch", "OK");
                return false;
            }
            if (lblFromDateText.Text == "From" || lblToDateText.Text == "To")
            {
                DisplayAlert("Error", "Please select the date", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(txtPercentage.Text))
            {
                DisplayAlert("Error", "Please enter a value for Percentage", "OK");
                return false;
            }
            if (txtPercentage.TextColor == Color.Red)
            {
                DisplayAlert("Error", "Please enter a valid Percentage", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(txtProjectInformation.Text))
            {
                DisplayAlert("Error", "Please enter a value for Project Information", "OK");
                return false;
            }
            
            return true;
        }
        #endregion

    }
}
