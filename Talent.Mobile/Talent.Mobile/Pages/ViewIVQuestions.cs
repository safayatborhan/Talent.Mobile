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
    class ViewIVQuestions : BasePage
    {
        #region constructor
        public ViewIVQuestions()
        {
            List<Models.InterviewQuestions> intvDetList = new List<Models.InterviewQuestions>();
            //Device.BeginInvokeOnMainThread(async () =>
            //{
            //    var result = await Service.GetEducationDetails(ACTContext.userId);

            //    if (result != null)
            //    {
            //        intvDetList = (List<Models.InterviewQuestions>)JsonConvert.DeserializeObject<List<Models.InterviewQuestions>>(result);
            //    }
            //});
            
            List<Department> deps = new List<Department>();
            List<Designation> desig = new List<Designation>();
            List<Stream> stream = new List<Stream>();
            Device.BeginInvokeOnMainThread(async () =>
            {
                var resDepartments = await Service.GetDepartments();

                var resDesigns = await Service.GetDesignations();

                var resStreams = await Service.GetStreams();

                if (resDepartments != null && resDesigns != null && resStreams != null)
                {
                    deps = (List<Department>)JsonConvert.DeserializeObject<List<Department>>(resDepartments);
                    desig = (List<Designation>)JsonConvert.DeserializeObject<List<Designation>>(resDesigns);
                    stream = (List<Stream>)JsonConvert.DeserializeObject<List<Stream>>(resStreams);
                    IVQuestionsLayout(deps,desig,stream);
                }

            });
            
        }
        #endregion

        #region initialize
        Picker pkrdeps = new Picker();
        Picker pkrdesig = new Picker();
        Picker pkrstream = new Picker();

        //Label lblFromDateText = new Label();
        //Label lblToDateText = new Label();
        

        //CustomEntryForGeneralPurpose txtPercentage = new CustomRenderer.CustomEntryForGeneralPurpose();
        //CustomEntryForGeneralPurpose txtProjectInformation = new CustomRenderer.CustomEntryForGeneralPurpose();

        //CustomEntryForGeneralPurpose txtBranch = new CustomEntryForGeneralPurpose();

        TapGestureRecognizer recognizerdeps = new TapGestureRecognizer();
        TapGestureRecognizer recognizerdesig = new TapGestureRecognizer();
        TapGestureRecognizer recognizerstream = new TapGestureRecognizer();

        List<InterviewQuestions> IVObservableCollection = new List<InterviewQuestions>();
        ListView listView = new ListView();

        StackLayout slEducationAllInformationAdd = new StackLayout();

        List<InterviewSet> intss = new List<InterviewSet>();
        #endregion        

        public void IVQuestionsLayout(List<Department> deps, List<Designation> desig, List<Stream> streams)
        {
            if (ACTContext.isLogin == true)
            {
                //#region add education detail button
                //Button btnAddNewWorkExp = new Button { Text = "Add education detail", HorizontalOptions = LayoutOptions.EndAndExpand, BackgroundColor = Color.FromHex("4690FB"), TextColor = Color.White, BorderRadius = 10, HeightRequest = 35, FontSize = 10, FontAttributes = FontAttributes.Bold };
                //StackLayout sBtnAddNewWorkExp = new StackLayout
                //{
                //    Children = { btnAddNewWorkExp },
                //    Orientation = StackOrientation.Horizontal,
                //    Padding = new Thickness(2, 5, 2, 5)
                //};
                //#endregion

                #region university, college, pkrQualification, pkrDegree pickers
                Label lblEducationDetailsInfo = new Label { Text = "View Interview Questions", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.FromHex("5e247f"), FontSize = 18, FontAttributes = FontAttributes.Bold, HeightRequest = 30 };
                StackLayout sEducationDetailInfo = new StackLayout
                {
                    Children = { lblEducationDetailsInfo },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 50, 0, 10)
                };
                Seperator sListViewHeader = new Seperator();
                //pkrUniversityName = new Picker { Title="University Name", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Gray };            
                //foreach (UniversityModel item in university)
                //{
                //    pkrUniversityName.Items.Add(item.pkrUniversityName);
                //}           
                //StackLayout spkrUniversityName = new StackLayout
                //{
                //    Children = { pkrUniversityName },
                //    Orientation = StackOrientation.Horizontal,
                //    Padding = new Thickness(0, 0, 0, 0)
                //};

                #region dept
                Label lblUniversityPickerTitle = new Label { Text = "Interview Questions", TextColor = Color.Gray };
                pkrdeps = new Picker { IsVisible = false };
                pkrdeps.Title = "Interview Questions";
                foreach (Department item in deps)
                {
                    pkrdeps.Items.Add(item.DepartmentName);
                }
                pkrdeps.SelectedIndexChanged += (s, e) =>
                {
                    lblUniversityPickerTitle.TextColor = Color.Black;
                    lblUniversityPickerTitle.Text = pkrdeps.Items[pkrdeps.SelectedIndex].ToString();
                };
                Image imgpkrUniversityNameDropdown = new Image { Source = "dropdownPicker.png", HorizontalOptions = LayoutOptions.EndAndExpand };

                StackLayout spkrUniversityName = new StackLayout { Children = { lblUniversityPickerTitle, pkrdeps, imgpkrUniversityNameDropdown }, Orientation = StackOrientation.Horizontal, Padding = new Thickness(0, 5, 0, 5) };
                Frame frmpkrUniversityName = new Frame { Content = spkrUniversityName, BackgroundColor = Color.White, Padding = new Thickness(Device.OnPlatform(8, 5, 0)), HasShadow = false };

                recognizerdeps.NumberOfTapsRequired = 1; // single-tap
                recognizerdeps.Tapped += (s, e) =>
                {
                    pkrdeps.Focus();
                };
                frmpkrUniversityName.GestureRecognizers.Add(recognizerdeps);
                Seperator universityNameSeparator = new Seperator();
                #endregion

                #region college name
                Label lblCollegePickerTitle = new Label { Text = "Designation", TextColor = Color.Gray };
                pkrdesig = new Picker { IsVisible = false };
                pkrdesig.Title = "Designation Name";
                foreach (Designation item in desig)
                {
                    pkrdesig.Items.Add(item.DesignationName);
                }
                pkrdesig.SelectedIndexChanged += (s, e) =>
                {
                    lblCollegePickerTitle.TextColor = Color.Black;
                    lblCollegePickerTitle.Text = pkrdesig.Items[pkrdesig.SelectedIndex].ToString();
                };
                Image imgCollegeNameDropdown = new Image { Source = "dropdownPicker.png", HorizontalOptions = LayoutOptions.EndAndExpand };

                StackLayout sCollegeName = new StackLayout { Children = { lblCollegePickerTitle, pkrdesig, imgCollegeNameDropdown }, Orientation = StackOrientation.Horizontal, Padding = new Thickness(0, 5, 0, 5) };
                Frame frmCollegeName = new Frame { Content = sCollegeName, BackgroundColor = Color.White, Padding = new Thickness(Device.OnPlatform(8, 5, 0)), HasShadow = false };

                recognizerdesig.NumberOfTapsRequired = 1; // single-tap
                recognizerdesig.Tapped += (s, e) =>
                {
                    pkrdesig.Focus();
                };
                frmCollegeName.GestureRecognizers.Add(recognizerdesig);
                Seperator collegeNameSeparator = new Seperator();
                #endregion

                #region stream
                Label lblQualificationPickerTitle = new Label { Text = "Stream", TextColor = Color.Gray, FontSize = Device.OnPlatform(11, 14, 14) };
                pkrstream = new Picker { IsVisible = false };
                pkrstream.Title = "Stream";
                foreach (Stream item in streams)
                {
                    pkrstream.Items.Add(item.StreamName);
                }
                pkrstream.SelectedIndexChanged += (s, e) =>
                {
                    lblQualificationPickerTitle.TextColor = Color.Black;
                    lblQualificationPickerTitle.Text = pkrstream.Items[pkrstream.SelectedIndex].ToString();
                };
                Image imgQualificationDropdown = new Image { Source = "dropdownPicker.png", HorizontalOptions = LayoutOptions.EndAndExpand };

                StackLayout sQualificationName = new StackLayout { Children = { lblQualificationPickerTitle, pkrstream, imgQualificationDropdown }, Orientation = StackOrientation.Horizontal, Padding = new Thickness(0, 5, 0, 5) };
                Frame frmQualification = new Frame { Content = sQualificationName, BackgroundColor = Color.White, Padding = new Thickness(Device.OnPlatform(8, 5, 0)), HasShadow = false };

                recognizerstream.NumberOfTapsRequired = 1; // single-tap
                recognizerstream.Tapped += (s, e) =>
                {
                    pkrstream.Focus();
                };
                frmQualification.GestureRecognizers.Add(recognizerstream);
                Seperator qualificationSeparator = new Seperator();
                #endregion

                //#region degree
                //Label lblDegreePickerTitle = new Label { Text = "Degree", TextColor = Color.Gray };
                //pkrDegree = new Picker { IsVisible = false };
                //pkrDegree.Title = "Degree";
                //foreach (Degree item in degrees)
                //{
                //    pkrDegree.Items.Add(item.DegreeName);
                //}
                //pkrDegree.SelectedIndexChanged += (s, e) =>
                //{
                //    lblDegreePickerTitle.TextColor = Color.Black;
                //    lblDegreePickerTitle.Text = pkrDegree.Items[pkrDegree.SelectedIndex].ToString();
                //};
                //Image imgDegreeDropdown = new Image { Source = "dropdownPicker.png", HorizontalOptions = LayoutOptions.EndAndExpand };

                //StackLayout sDegreeName = new StackLayout { Children = { lblDegreePickerTitle, pkrDegree, imgDegreeDropdown }, Orientation = StackOrientation.Horizontal, Padding = new Thickness(0, 5, 0, 5) };
                //Frame frmDegree = new Frame { Content = sDegreeName, BackgroundColor = Color.White, Padding = new Thickness(Device.OnPlatform(8, 5, 0)), HasShadow = false };

                //recognizerDegree.NumberOfTapsRequired = 1; // single-tap
                //recognizerDegree.Tapped += (s, e) =>
                //{
                //    pkrDegree.Focus();
                //};
                //frmDegree.GestureRecognizers.Add(recognizerDegree);
                //Seperator degreeSeparator = new Seperator();
                //#endregion

                //#endregion

                //#region branch
                //txtBranch = new CustomEntryForGeneralPurpose { Placeholder = "Branch", HorizontalOptions = LayoutOptions.FillAndExpand };
                //StackLayout sBranch = new StackLayout
                //{
                //    Children = { txtBranch },
                //    Orientation = StackOrientation.Horizontal,
                //    Padding = new Thickness(0, 0, 0, 0)
                //};
                //Seperator seperatorBranch = new Seperator();
                //#endregion

                //#region duration
                //Label lblDuration = new Label { Text = "Duration", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Gray, WidthRequest = 80, HeightRequest = 30 };
                //StackLayout slblDuration = new StackLayout
                //{
                //    Children = { lblDuration },
                //    Orientation = StackOrientation.Horizontal,
                //    HorizontalOptions = LayoutOptions.End,
                //    Margin = new Thickness(3, 8, 0, 0)
                //};

                //lblFromDateText = new Label { Text = "From", HorizontalOptions = LayoutOptions.Center, TextColor = Color.Gray };

                //StackLayout sLblFromDateText = new StackLayout
                //{
                //    Children = { lblFromDateText },
                //    Orientation = StackOrientation.Horizontal,
                //    Margin = new Thickness(0, 8, 0, 0)
                //};

                //Image imgFromDateArrow = new Image { Source = "calendar.png", HorizontalOptions = LayoutOptions.End };

                //StackLayout slFromDateTap = new StackLayout { Children = { sLblFromDateText, imgFromDateArrow }, Orientation = StackOrientation.Horizontal };

                //DatePicker dtFromDate = new DatePicker { IsVisible = false, BackgroundColor = Color.White };
                //var fromDateTapGestureRecognizer = new TapGestureRecognizer();

                //fromDateTapGestureRecognizer.NumberOfTapsRequired = 1; // single-tap
                //fromDateTapGestureRecognizer.Tapped += (s, e) =>
                //{
                //    dtFromDate.Focus();
                //};

                //slFromDateTap.GestureRecognizers.Add(fromDateTapGestureRecognizer);

                //dtFromDate.DateSelected += (object sender, DateChangedEventArgs e) =>
                //{
                //    //lblFromDateText.Text = e.NewDate.ToString("dd-MM-yyyy");
                //    lblFromDateText.Text = e.NewDate.ToString("yyyy-MM-dd");
                //};

                ////To date
                //lblToDateText = new Label { Text = "To", HorizontalOptions = LayoutOptions.Center, TextColor = Color.Gray };

                //StackLayout sLblToDateText = new StackLayout
                //{
                //    Children = { lblToDateText },
                //    Orientation = StackOrientation.Horizontal,
                //    Margin = new Thickness(0, 8, 0, 0)
                //};

                //Image imgToDateArrow = new Image { Source = "calendar.png", HorizontalOptions = LayoutOptions.End };

                //StackLayout slToDateTap = new StackLayout { Children = { sLblToDateText, imgToDateArrow }, Orientation = StackOrientation.Horizontal };

                //DatePicker dtToDate = new DatePicker { IsVisible = false, BackgroundColor = Color.White };
                //var toDateTapGestureRecognizer = new TapGestureRecognizer();

                //toDateTapGestureRecognizer.NumberOfTapsRequired = 1; // single-tap
                //toDateTapGestureRecognizer.Tapped += (s, e) =>
                //{
                //    dtToDate.Focus();
                //};

                //slToDateTap.GestureRecognizers.Add(toDateTapGestureRecognizer);

                //dtToDate.DateSelected += (object sender, DateChangedEventArgs e) =>
                //{
                //    //lblToDateText.Text = e.NewDate.ToString("dd-MM-yyyy");
                //    lblToDateText.Text = e.NewDate.ToString("yyyy-MM-dd");
                //};

                //Label lblFromToTo = new Label { Text = "-", HorizontalOptions = LayoutOptions.Center, TextColor = Color.Gray };

                //StackLayout sLblFromToTo = new StackLayout
                //{
                //    Children = { lblFromToTo },
                //    Orientation = StackOrientation.Horizontal,
                //    Margin = new Thickness(0, 8, 0, 0)
                //};

                //StackLayout sWorkDuration = new StackLayout
                //{
                //    Children = { slblDuration, slFromDateTap, dtFromDate, sLblFromToTo, slToDateTap, dtToDate },
                //    Orientation = StackOrientation.Horizontal,
                //    Padding = new Thickness(0, 0, 0, 0)
                //};
                //Seperator sDuration = new Seperator();
                //#endregion

                //#region percentage, project info, aftersave response, button
                //txtPercentage = new CustomEntryForGeneralPurpose { Placeholder = "Percentage", HorizontalOptions = LayoutOptions.FillAndExpand, Keyboard = Keyboard.Numeric };
                //txtPercentage.Behaviors.Add(new DecimalNumberValidationBehaviour());
                //StackLayout sPercentage = new StackLayout
                //{
                //    Children = { txtPercentage },
                //    Orientation = StackOrientation.Horizontal,
                //    Padding = new Thickness(0, 0, 0, 0)
                //};
                //Seperator sPercentageText = new Seperator();
                //txtProjectInformation = new CustomEntryForGeneralPurpose { Placeholder = "Project Information", HorizontalOptions = LayoutOptions.FillAndExpand };
                //StackLayout sProjectInformation = new StackLayout
                //{
                //    Children = { txtProjectInformation },
                //    Orientation = StackOrientation.Horizontal,
                //    Padding = new Thickness(0, 0, 0, 0)
                //};
                //Seperator sProjectInfo = new Seperator();
                //Label AfterSaveResponse = new Label { Text = "", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Green };
                //StackLayout slAfterSaveResponse = new StackLayout
                //{
                //    Children = { AfterSaveResponse },
                //    Orientation = StackOrientation.Horizontal,
                //    Margin = new Thickness(0, 8, 0, 0)
                //};

                Button btnSaveData = new Button { Text = "View Questions", HorizontalOptions = LayoutOptions.CenterAndExpand, BackgroundColor = Color.FromHex("f7cc59"), TextColor = Color.Black, BorderRadius = 50, WidthRequest = 270, FontAttributes = FontAttributes.Bold };
                StackLayout sbtnSaveData = new StackLayout
                {
                    Children = { btnSaveData },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 10, 0, 8)
                };
                //#endregion

                //#region listView

                //Label lblAddNewEducationDetail = new Label { Text = "Add new education detail information here", HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f"), FontSize = 14, FontAttributes = FontAttributes.Bold };
                //StackLayout slblAddNewEducationDetail = new StackLayout
                //{
                //    Children = { lblAddNewEducationDetail },
                //    Orientation = StackOrientation.Horizontal,
                //    Padding = new Thickness(0, 20, 0, 0)
                //};

                //StackLayout slHeaderText = new StackLayout();
                //Label lblColege = new Label { Text = "College", FontAttributes = FontAttributes.Bold, WidthRequest = 130, HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f") };
                //Label lblpkrDegree = new Label { Text = "Degree", FontAttributes = FontAttributes.Bold, WidthRequest = 130, HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f") };
                //Label lblPercentage = new Label { Text = "Percentage", FontAttributes = FontAttributes.Bold, WidthRequest = 130, HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f") };
                //Label lblEmpty = new Label { Text = "", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black };
                //slHeaderText = new StackLayout
                //{
                //    Children = { lblColege, lblpkrDegree, lblPercentage, lblEmpty },
                //    Orientation = StackOrientation.Horizontal,
                //    Padding = new Thickness(0, 0, 0, 0)
                //};
                //if(educationList.Count == 0)
                //{
                //    slHeaderText.IsVisible = false;
                //    sListViewHeader.IsVisible = false;
                //}


                //educationObservableCollection = educationList;

                //listView.ItemsSource = educationObservableCollection;
                //listView.ItemTemplate = new DataTemplate(() => new EducationCell(educationObservableCollection, college, qualifications));
                //listView.HeightRequest = 50 * educationList.Count;
                //StackLayout sListView = new StackLayout
                //{
                //    Children = { listView },
                //    Orientation = StackOrientation.Horizontal,
                //    Padding = new Thickness(0, 0, 0, 0)
                //};

                //#endregion

                //#region stack layout, scroll view and content

                slEducationAllInformationAdd = new StackLayout
                {
                    Children = { //slblAddNewEducationDetail,
                    frmpkrUniversityName, universityNameSeparator, frmCollegeName, collegeNameSeparator,
                    frmQualification, qualificationSeparator,
                        //frmDegree, degreeSeparator, sBranch, seperatorBranch,
                        //sWorkDuration, sDuration, sPercentage, sPercentageText,
                        //sProjectInformation, sProjectInfo, slAfterSaveResponse, 
                        sbtnSaveData
                     }
                };
                slEducationAllInformationAdd.IsVisible = true;
                //btnAddNewWorkExp.Clicked += (object sender, EventArgs e) =>
                //{
                //    slEducationAllInformationAdd.IsVisible = true;
                //};
                #endregion

                #region posting data
                InterviewQuestions interrviewQues = new InterviewQuestions();
                

                StackLayout slHeaderText = new StackLayout();
                StackLayout slEducationDetailsInformation = new StackLayout();
                StackLayout sListView = new StackLayout();

                btnSaveData.Clicked += (object sender, EventArgs e) =>
                {
                    sListView.IsVisible = true;
                    if (Validate())
                    {

                        //interrviewQues.deptId = ACTContext.userId;
                        interrviewQues.deptId = (from c in deps where c.DepartmentName == pkrdeps.Items[pkrdeps.SelectedIndex] select c.DepartmentId).SingleOrDefault();
                        interrviewQues.desigId = (from d in desig where d.DesignationName == pkrdesig.Items[pkrdesig.SelectedIndex] select d.DesignationId).SingleOrDefault();
                        interrviewQues.streamId = (from c in streams where c.StreamName == pkrstream.Items[pkrstream.SelectedIndex] select c.StreamID).SingleOrDefault();

                        //slHeaderText.IsVisible = true;
                        sListViewHeader.IsVisible = true;

                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            var resInS = await Service.GetIvQuestionsDetails(interrviewQues);
                            if (resInS != null)
                            {
                                intss = (List<InterviewSet>)JsonConvert.DeserializeObject<List<InterviewSet>>(resInS);
                            }
                            List<InterviewSet> interviewSetObservableCollection = new List<InterviewSet>();
                            interviewSetObservableCollection = intss;

                            Label lblQ = new Label { Text = "Question", FontAttributes = FontAttributes.Bold, WidthRequest = 130, HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f") };
                            Label lblA = new Label { Text = "Answer", FontAttributes = FontAttributes.Bold, WidthRequest = 130, HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f") };
                            slHeaderText = new StackLayout
                            {
                                Children = { lblQ, lblA },
                                Orientation = StackOrientation.Horizontal,
                                Padding = new Thickness(0, 0, 0, 0)
                            };
                            if (intss.Count == 0)
                            {
                                slHeaderText.IsVisible = false;
                                sListViewHeader.IsVisible = false;
                            }
                            listView.ItemsSource = intss;
                            //listView.ItemTemplate = new DataTemplate(() => new InterviewQuestionsCell(intss));
                            listView.ItemTemplate = new DataTemplate(() => new InterviewQuestionsCell(interviewSetObservableCollection));
                            listView.HeightRequest = 50 * intss.Count;
                            

                        });
                    };

                };

                //StackLayout slHeaderText = new StackLayout();


                #endregion

                #region listview
                sListView = new StackLayout
                {
                    Children = { listView },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                sListView.IsVisible = false;
                #endregion

                slEducationDetailsInformation = new StackLayout
                {
                    Children = { /*sBtnAddNewWorkExp,*/ sEducationDetailInfo, slHeaderText, sListViewHeader, sListView, slEducationAllInformationAdd },
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Padding = new Thickness(20, 0, 20, 30),
                    BackgroundColor = Color.White
                };

                ScrollView svEducationDetails = new ScrollView { Content = slEducationDetailsInformation };

                Content = svEducationDetails;
            }
            else
            {
                Navigation.PushModalAsync(new Login());
            }
        }
        #region validation
        private bool Validate()
        {
            //if (pkrUniversityName.SelectedIndex == -1)
            //{
            //    DisplayAlert("Error", "Please select a value for University Name", "OK");
            //    return false;
            //}
            //if (pkrCollegeName.SelectedIndex == -1)
            //{
            //    DisplayAlert("Error", "Please select a value for College Name", "OK");
            //    return false;
            //}
            //if (pkrQualification.SelectedIndex == -1)
            //{
            //    DisplayAlert("Error", "Please select a value for Qualificaiton", "OK");
            //    return false;
            //}
            //if (pkrDegree.SelectedIndex == -1)
            //{
            //    DisplayAlert("Error", "Please select a value for pkrDegree", "OK");
            //    return false;
            //}
            //if (string.IsNullOrEmpty(txtBranch.Text))
            //{
            //    DisplayAlert("Error", "Please enter a value for Branch", "OK");
            //    return false;
            //}
            //if (lblFromDateText.Text == "From" || lblToDateText.Text == "To")
            //{
            //    DisplayAlert("Error", "Please select the date", "OK");
            //    return false;
            //}
            
            //if (string.IsNullOrEmpty(txtPercentage.Text))
            //{
            //    DisplayAlert("Error", "Please enter a value for Percentage", "OK");
            //    return false;
            //}
            //if (txtPercentage.TextColor == Color.Red)
            //{
            //    DisplayAlert("Error", "Please enter a valid Percentage", "OK");
            //    return false;
            //}
            //if (string.IsNullOrEmpty(txtProjectInformation.Text))
            //{
            //    DisplayAlert("Error", "Please enter a value for Project Information", "OK");
            //    return false;
            //}
            return true;
        }
        #endregion

    }
}
