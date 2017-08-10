using DevenvExeBehaviors;
using ImageCircle.Forms.Plugin.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Context;
using Talent.Mobile.Controls;
using Talent.Mobile.Controls.Cell;
using Talent.Mobile.CustomRenderer;
using Talent.Mobile.Models;
using Talent.Mobile.Models.Models;
using Xamarin.Forms;

namespace Talent.Mobile.Pages.User
{
    class WorkExperience : BasePage
    {
        #region constructor               
        public WorkExperience()
        {
            List<WorkExperienceModel> workExperienceList = new List<WorkExperienceModel>();
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await Service.GetWorkExpById(ACTContext.userId);  //63

                if (result != null)
                {
                    workExperienceList = (List<WorkExperienceModel>)JsonConvert.DeserializeObject<List<WorkExperienceModel>>(result);
                    WorkExperienceLayout(workExperienceList);
                }
            });
        }
        #endregion

        #region intialize
        StackLayout slForOnsiteInformation = new StackLayout();

        CustomEntryForGeneralPurpose CompanyName = new CustomEntryForGeneralPurpose();
        CustomEntryForGeneralPurpose workDesignation = new CustomEntryForGeneralPurpose();
        CustomEntryForGeneralPurpose workRole = new CustomEntryForGeneralPurpose();

        Label lblFromDateText = new Label();
        Label lblToDateText = new Label();

        CustomEntryForGeneralPurpose workReferenceContact = new CustomEntryForGeneralPurpose();
        CustomEntryForGeneralPurpose workPhoneNo = new CustomEntryForGeneralPurpose();

        CustomEntryForGeneralPurpose onsiteWorkedCompany = new CustomEntryForGeneralPurpose();
        CustomEntryForGeneralPurpose onsiteWorkedCompanyLocation = new CustomEntryForGeneralPurpose();

        Label lblFromDateOnsiteText = new Label();
        Label lblToDateOnsiteText = new Label();

        CustomEntryForGeneralPurpose onsiteWorkedCompanyDetail = new CustomEntryForGeneralPurpose();
        CustomEntryForGeneralPurpose onsiteWorkedCompanyReferenceContact = new CustomEntryForGeneralPurpose();
        CustomEntryForGeneralPurpose onsiteWorkedCompanyPhoneNo = new CustomEntryForGeneralPurpose();

        ListView listView = new ListView();
        List<WorkExperienceModel> workExperienceObservableCollection = new List<WorkExperienceModel>();

        ListView listViewOnsiteDetail = new ListView();
        List<Onsite> onsiteDetailObservableCollection = new List<Onsite>();

        StackLayout slAddAllExperienceInformation = new StackLayout();
        #endregion

        public void WorkExperienceLayout(List<WorkExperienceModel> workExperienceList)
        {
            if (ACTContext.isLogin == true)
            {
                #region work experience and onsite labels add button
                Label lblOnsiteSwithInfo = new Label { Text = "Onsite Information ", HorizontalOptions = LayoutOptions.EndAndExpand, TextColor = Color.FromHex("5e247f"), FontSize = 12, FontAttributes = FontAttributes.Bold };
                Switch switchForOnsite1 = new Switch { HorizontalOptions = LayoutOptions.End, BackgroundColor = Color.Transparent };
                StackLayout sSwithForOnsite = new StackLayout
                {
                    Children = { lblOnsiteSwithInfo, switchForOnsite1 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 20, 0, 0)
                };
                Button btnAddNewWorkExp = new Button { Text = "Add work experience", HorizontalOptions = LayoutOptions.EndAndExpand, BackgroundColor = Color.FromHex("4690FB"), TextColor = Color.White, BorderRadius = 10, HeightRequest=35, FontSize = 10, FontAttributes = FontAttributes.Bold };
                StackLayout sBtnAddNewWorkExp = new StackLayout
                {
                    Children = { btnAddNewWorkExp },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(2, 5, 2, 5)
                };


                Label lblCompanyWorkExperienceInfo = new Label { Text = "Work Experience Information", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.FromHex("5e247f"), FontSize = 18, FontAttributes = FontAttributes.Bold, HeightRequest = 30 };
                Label companyWorkExperience = new Label { Text = "", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, HeightRequest = 40 };
                StackLayout sCompanyWorkExperience = new StackLayout
                {
                    Children = { lblCompanyWorkExperienceInfo, companyWorkExperience },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 20, 0, 0)
                };

                Label lblOnsiteInformation = new Label { Text = "Onsite Information", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.FromHex("5e247f"), FontSize = 14, FontAttributes = FontAttributes.Bold, WidthRequest = 125, HeightRequest = 30 };
                StackLayout sOnsiteInformation = new StackLayout
                {
                    Children = { lblOnsiteInformation },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 20, 0, 0)
                };
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
                BoxView separator5 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator5 = new StackLayout
                {
                    Children = { separator5 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separator6 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator6 = new StackLayout
                {
                    Children = { separator6 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separator7 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator7 = new StackLayout
                {
                    Children = { separator7 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separator8 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator8 = new StackLayout
                {
                    Children = { separator8 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separator9 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator9 = new StackLayout
                {
                    Children = { separator9 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separator10 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator10 = new StackLayout
                {
                    Children = { separator10 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separator11 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator11 = new StackLayout
                {
                    Children = { separator11 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separator12 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparator12 = new StackLayout
                {
                    Children = { separator12 },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separatorListview = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparatorListview = new StackLayout
                {
                    Children = { separatorListview },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };

                BoxView separatorListviewOnsite = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sSeparatorListviewOnsite = new StackLayout
                {
                    Children = { separatorListviewOnsite },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                #endregion

                #region company name, designation, role

                Label lblAddNewWorkExp = new Label { Text = "Add new work experience information here", HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f"), FontSize = 14, FontAttributes = FontAttributes.Bold };
                StackLayout slblAddNewWorkExp = new StackLayout
                {
                    Children = { lblAddNewWorkExp },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 20, 0, 0)
                };

                CompanyName = new CustomEntryForGeneralPurpose { Placeholder = "Company Name", HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sCompanyName = new StackLayout
                {
                    Children = { CompanyName },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };

                workDesignation = new CustomEntryForGeneralPurpose { Placeholder = "Designation", HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sWorkDesignation = new StackLayout
                {
                    Children = { workDesignation },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };

                workRole = new CustomEntryForGeneralPurpose { Placeholder = "Role", HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sWorkRole = new StackLayout
                {
                    Children = { workRole },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                
                #endregion

                #region duration
                Label lblWorkDuration = new Label { Text = "Duration", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Gray, WidthRequest = 80, HeightRequest = 30 };
                StackLayout slblWorkDuration = new StackLayout
                {
                    Children = { lblWorkDuration },
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(0, 8, 0, 0)
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
                    Children = { slblWorkDuration, slFromDateTap, dtFromDate, sLblFromToTo, slToDateTap, dtToDate },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(3, 0, 0, 0)
                };
                #endregion duration

                #region contacts                
                workReferenceContact = new CustomEntryForGeneralPurpose { Placeholder = "Reference Contact", HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sWorkReferenceContact = new StackLayout
                {
                    Children = { workReferenceContact },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };

                workPhoneNo = new CustomEntryForGeneralPurpose { Placeholder = "Phone No", HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sWorkPhoneNo = new StackLayout
                {
                    Children = { workPhoneNo },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                #endregion

                #region worked company and location

                Label lblAddNewOnsiteInfo = new Label { Text = "Add new onsite detail information here", HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f"), FontSize = 14, FontAttributes = FontAttributes.Bold };
                StackLayout slblAddNewOnsiteInfo = new StackLayout
                {
                    Children = { lblAddNewOnsiteInfo },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 20, 0, 0)
                };

                onsiteWorkedCompany = new CustomEntryForGeneralPurpose { Placeholder = "Worked Company", HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sOnsiteWorkedCompany = new StackLayout
                {
                    Children = { onsiteWorkedCompany },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };


                onsiteWorkedCompanyLocation = new CustomEntryForGeneralPurpose { Placeholder = "Location", HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sOnsiteWorkedCompanyLocation = new StackLayout
                {
                    Children = { onsiteWorkedCompanyLocation },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)

                };
                #endregion

                #region duration
                Label lblOnsiteWorkedCompanyDuration = new Label { Text = "Duration", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Gray, WidthRequest = 80, HeightRequest = 30 };
                StackLayout slblOnsiteWorkedCompanyDuration = new StackLayout
                {
                    Children = { lblOnsiteWorkedCompanyDuration },
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(0, 8, 0, 0)
                };

                lblFromDateOnsiteText = new Label { Text = "From", HorizontalOptions = LayoutOptions.Center, TextColor = Color.Gray };

                StackLayout slblFromDateOnsiteText = new StackLayout
                {
                    Children = { lblFromDateOnsiteText },
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(0, 8, 0, 0)
                };

                Image imgFromDateOnsiteArrow = new Image { Source = "calendar.png", HorizontalOptions = LayoutOptions.End };

                StackLayout slFromDateOnsiteTap = new StackLayout { Children = { slblFromDateOnsiteText, imgFromDateOnsiteArrow }, Orientation = StackOrientation.Horizontal };

                DatePicker dtFromOnsiteDate = new DatePicker { IsVisible = false, BackgroundColor = Color.White };
                var fromDateOnsiteTapGestureRecognizer = new TapGestureRecognizer();

                fromDateOnsiteTapGestureRecognizer.NumberOfTapsRequired = 1; // single-tap
                fromDateOnsiteTapGestureRecognizer.Tapped += (s, e) =>
                {
                    dtFromOnsiteDate.Focus();
                };

                slFromDateOnsiteTap.GestureRecognizers.Add(fromDateOnsiteTapGestureRecognizer);

                dtFromOnsiteDate.DateSelected += (object sender, DateChangedEventArgs e) =>
                {
                    lblFromDateOnsiteText.Text = e.NewDate.ToString("yyyy-MM-dd");
                };

                //To date
                lblToDateOnsiteText = new Label { Text = "To", HorizontalOptions = LayoutOptions.Center, TextColor = Color.Gray };

                StackLayout slblToDateOnsiteText = new StackLayout
                {
                    Children = { lblToDateOnsiteText },
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(0, 8, 0, 0)
                };

                Image imgToDateOnsiteArrow = new Image { Source = "calendar.png", HorizontalOptions = LayoutOptions.End };

                StackLayout slToDateOnsiteTap = new StackLayout { Children = { slblToDateOnsiteText, imgToDateOnsiteArrow }, Orientation = StackOrientation.Horizontal };

                DatePicker dtToDateOnsite = new DatePicker { IsVisible = false, BackgroundColor = Color.White };
                var toDateOnsiteTapGestureRecognizer = new TapGestureRecognizer();

                toDateOnsiteTapGestureRecognizer.NumberOfTapsRequired = 1; // single-tap
                toDateOnsiteTapGestureRecognizer.Tapped += (s, e) =>
                {
                    dtToDateOnsite.Focus();
                };

                slToDateOnsiteTap.GestureRecognizers.Add(toDateOnsiteTapGestureRecognizer);

                dtToDateOnsite.DateSelected += (object sender, DateChangedEventArgs e) =>
                {
                    lblToDateOnsiteText.Text = e.NewDate.ToString("yyyy-MM-dd");

                };

                Label lblFromToToOnsite = new Label { Text = "-", HorizontalOptions = LayoutOptions.Center, TextColor = Color.Gray };

                StackLayout slblFromToToOnsite = new StackLayout
                {
                    Children = { lblFromToToOnsite },
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(0, 8, 0, 0)
                };

                StackLayout sOnsiteWorkedCompanyDuration = new StackLayout
                {
                    Children = { slblOnsiteWorkedCompanyDuration, slFromDateOnsiteTap, dtFromOnsiteDate, slblFromToToOnsite, slToDateOnsiteTap, dtToDateOnsite },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(3, 0, 0, 0)
                };
                #endregion

                #region onsite detail, contacts
                onsiteWorkedCompanyDetail = new CustomEntryForGeneralPurpose { Placeholder = "Onsite Detail", HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sOnsiteWorkedCompanyDetail = new StackLayout
                {
                    Children = { onsiteWorkedCompanyDetail },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };


                onsiteWorkedCompanyReferenceContact = new CustomEntryForGeneralPurpose { Placeholder = "Reference Contact", HorizontalOptions = LayoutOptions.FillAndExpand, Keyboard = Keyboard.Numeric };
                onsiteWorkedCompanyReferenceContact.Behaviors.Add(new NumberValidationBehavior());
                StackLayout sOnsiteWorkedCompanyReferenceContact = new StackLayout
                {
                    Children = { onsiteWorkedCompanyReferenceContact },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };


                onsiteWorkedCompanyPhoneNo = new CustomEntryForGeneralPurpose { Placeholder = "Phone No", HorizontalOptions = LayoutOptions.FillAndExpand };
                StackLayout sOnsiteWorkedCompanyPhoneNo = new StackLayout
                {
                    Children = { onsiteWorkedCompanyPhoneNo },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                #endregion

                #region listView

                StackLayout slHeaderText = new StackLayout();
                Label lblCompany = new Label { Text = "Company", FontAttributes = FontAttributes.Bold, WidthRequest = 125, HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f") };
                Label lblRole = new Label { Text = "Role", FontAttributes = FontAttributes.Bold, WidthRequest = 125, HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f") };
                Label lblDesigation = new Label { Text = "Designation", FontAttributes = FontAttributes.Bold, WidthRequest = 125, HorizontalOptions = LayoutOptions.Start, TextColor = Color.FromHex("5e247f") };
                Label lblEmpty = new Label { Text = "", HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black };
                slHeaderText = new StackLayout
                {
                    Children = { lblCompany, lblRole, lblDesigation, lblEmpty },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 0, 0, 0)
                };

                if (workExperienceList.Count == 0)
                {
                    slHeaderText.IsVisible = false;
                    sSeparatorListview.IsVisible = false;
                }

                listView.HeightRequest = 50 * workExperienceList.Count;
                workExperienceObservableCollection = workExperienceList;

                listView.ItemsSource = workExperienceObservableCollection;
                listView.ItemTemplate = new DataTemplate(() => new WorkExperienceCell(workExperienceObservableCollection));
                StackLayout sListView = new StackLayout
                {
                    Children = { listView },
                    //Orientation = StackOrientation.Horizontal,
                    //Padding = new Thickness(0, 0, 0, 0)
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Orientation = StackOrientation.Vertical
                };
                listView.MinimumHeightRequest = listView.Height;
                listView.BackgroundColor = Color.Transparent;
                #endregion

                #region contents, button
                slForOnsiteInformation = new StackLayout
                {
                    Children = { sOnsiteInformation, slblAddNewOnsiteInfo, sOnsiteWorkedCompany,
                        sSeparator7, sOnsiteWorkedCompanyLocation,
                        sSeparator8, sOnsiteWorkedCompanyDuration,
                        sSeparator9, sOnsiteWorkedCompanyDetail, sSeparator10, sOnsiteWorkedCompanyReferenceContact, sSeparator11, sOnsiteWorkedCompanyPhoneNo, sSeparator12 },
                    IsVisible = false
                };

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

                #region stack layout for adding all work experience info
                slAddAllExperienceInformation = new StackLayout
                {
                    Children = { slblAddNewWorkExp, sCompanyName, sSeparator1, sWorkDesignation, sSeparator2, sWorkRole, sSeparator3, sWorkDuration, sSeparator4, sWorkReferenceContact, sSeparator5, sWorkPhoneNo, sSeparator6, sSwithForOnsite }
                };
                slAddAllExperienceInformation.IsVisible = false;
                sbtnSaveData.IsVisible = false;
                btnAddNewWorkExp.Clicked += (object sender, EventArgs e) =>
                {
                    slAddAllExperienceInformation.IsVisible = true;
                    sbtnSaveData.IsVisible = true;
                };
                #endregion

                StackLayout slWorkExperienceInfo = new StackLayout
                {
                    //Children = { sSwithForOnsite, sCompanyWorkExperience, sCompanyName, sWorkDesignation, sWorkRole, sWorkDuration, sWorkReferenceContact, sWorkPhoneNo, sOnsiteInformation, sOnsiteWorkedCompany, sOnsiteWorkedCompanyLocation, sOnsiteWorkedCompanyDuration, sOnsiteWorkedCompanyDetail, sOnsiteWorkedCompanyReferenceContact, slForOnsiteInformation, slAfterSaveResponse, sbtnSaveData },
                    Children = { sBtnAddNewWorkExp, sCompanyWorkExperience, slHeaderText, sSeparatorListview, sListView, slAddAllExperienceInformation, slForOnsiteInformation, slAfterSaveResponse, sbtnSaveData },
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Padding = new Thickness(20, 0, 20, 0),
                    BackgroundColor = Color.White
                };

                ScrollView svMyProfile = new ScrollView { Content = slWorkExperienceInfo };

                Content = svMyProfile;
                #endregion

                #region post data to server side
                WorkExperienceModel workExperienceModel = new WorkExperienceModel();
                Onsite onsite = new Onsite();
                switchForOnsite1.Toggled += (object sender, ToggledEventArgs e) =>
                {

                    slForOnsiteInformation.IsVisible = true;
                    if (switchForOnsite1.IsToggled == false)
                    {
                        slForOnsiteInformation.IsVisible = false;
                    }
                };
                btnSaveData.Clicked += (object sender, EventArgs e) =>
                {
                    if (Validate())
                    {
                        if(DateTime.Parse(lblFromDateText.Text) > DateTime.Parse(lblToDateText.Text))
                        {
                            DisplayAlert("Error", "Start date can not be greater than end date.", "OK");
                        }
                        else if (slForOnsiteInformation.IsVisible == true && (DateTime.Parse(lblFromDateOnsiteText.Text) > DateTime.Parse(lblToDateOnsiteText.Text)))
                        {
                            DisplayAlert("Error", "Start date can not be greater than end date for onsite.", "OK");
                        }
                        else
                        {
                            workExperienceModel.UserId = ACTContext.userId;
                            workExperienceModel.Company = CompanyName.Text;
                            workExperienceModel.Role = workRole.Text;
                            workExperienceModel.Designation = workDesignation.Text;
                            workExperienceModel.FromDate = DateTime.Parse(lblFromDateText.Text);
                            workExperienceModel.ToDate = DateTime.Parse(lblToDateText.Text);
                            workExperienceModel.ExperienceBrief = companyWorkExperience.Text;
                            workExperienceModel.ReferenceContact = workReferenceContact.Text;
                            workExperienceModel.ExperoenceYear = 5;

                            slHeaderText.IsVisible = true;
                            sSeparatorListview.IsVisible = true;

                            onsite.OnsiteDetails = onsiteWorkedCompanyDetail.Text;
                            if (slForOnsiteInformation.IsVisible == true)
                            {
                                onsite.StartDate = DateTime.Parse(lblFromDateOnsiteText.Text);
                                onsite.EndDate = DateTime.Parse(lblToDateOnsiteText.Text);
                            }
                            if (slForOnsiteInformation.IsVisible == false)
                            {
                                onsite.StartDate = DateTime.Now;
                                onsite.EndDate = DateTime.Now;
                            }
                            if (slForOnsiteInformation.IsVisible == true)
                            {
                                onsite.ContactDetails = int.Parse(onsiteWorkedCompanyReferenceContact.Text);
                            }
                            if (slForOnsiteInformation.IsVisible == false)
                            {
                                onsite.ContactDetails = 0;
                            }
                            onsite.Location = onsiteWorkedCompanyLocation.Text;

                            if (slForOnsiteInformation.IsVisible == false)
                            {
                                workExperienceModel.onsite = null;
                            }
                            if (slForOnsiteInformation.IsVisible == true)
                            {
                                workExperienceModel.onsite = onsite;
                            }


                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                var result = await Service.PostWorkExperience(workExperienceModel);
                                CompanyName.Text = string.Empty;
                                workDesignation.Text = string.Empty;
                                workRole.Text = string.Empty;
                                workReferenceContact.Text = string.Empty;
                                workPhoneNo.Text = string.Empty;
                                onsiteWorkedCompany.Text = string.Empty;
                                onsiteWorkedCompanyLocation.Text = string.Empty;
                                onsiteWorkedCompanyDetail.Text = string.Empty;
                                onsiteWorkedCompanyDetail.Text = string.Empty;
                                onsiteWorkedCompanyPhoneNo.Text = string.Empty;
                                onsiteWorkedCompanyReferenceContact.Text = string.Empty;



                                AfterSaveResponse.Text = "Data saved successfully";

                                var resultUpdated = await Service.GetWorkExpById(ACTContext.userId);   //63

                                var resultForOnsiteUpdated = await Service.GetOnsiteInfo(ACTContext.userId);   //63

                                if (resultUpdated != null)
                                {
                                    workExperienceList = (List<WorkExperienceModel>)JsonConvert.DeserializeObject<List<WorkExperienceModel>>(resultUpdated);
                                }
                                workExperienceObservableCollection = workExperienceList;
                                listView.HeightRequest = 50 * workExperienceList.Count;
                                listView.ItemsSource = workExperienceObservableCollection;
                                listView.ItemTemplate = new DataTemplate(() => new WorkExperienceCell(workExperienceObservableCollection));
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
            if (string.IsNullOrEmpty(CompanyName.Text))
            {
                DisplayAlert("Error", "Please enter a value for Company Name", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(workDesignation.Text))
            {
                DisplayAlert("Error", "Please enter a value for Designation", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(workRole.Text))
            {
                DisplayAlert("Error", "Please enter a value for Role", "OK");
                return false;
            }
            if (lblFromDateText.Text == "From" || lblToDateText.Text == "To")
            {
                DisplayAlert("Error", "Please select the date", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(workReferenceContact.Text))
            {
                DisplayAlert("Error", "Please enter a value for Reference Contact", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(workPhoneNo.Text))
            {
                DisplayAlert("Error", "Please enter a value for Phone No", "OK");
                return false;
            }

            if (slForOnsiteInformation.IsVisible == true)
            {
                if (string.IsNullOrEmpty(onsiteWorkedCompany.Text))
                {
                    DisplayAlert("Error", "Please enter a value for Onsite Company Name", "OK");
                    return false;
                }
                if (string.IsNullOrEmpty(onsiteWorkedCompanyLocation.Text))
                {
                    DisplayAlert("Error", "Please enter a value for Onsite Company Location", "OK");
                    return false;
                }
                
                if (lblFromDateOnsiteText.Text == "From" || lblToDateOnsiteText.Text == "To")
                {
                    DisplayAlert("Error", "Please select the date of onsite", "OK");
                    return false;
                }
                if (string.IsNullOrEmpty(onsiteWorkedCompanyDetail.Text))
                {
                    DisplayAlert("Error", "Please enter a value for Onsite Detail", "OK");
                    return false;
                }
                if (string.IsNullOrEmpty(onsiteWorkedCompanyReferenceContact.Text))
                {
                    DisplayAlert("Error", "Please enter a value for Onsite Reference Contact", "OK");
                    return false;
                }
                if (onsiteWorkedCompanyReferenceContact.TextColor == Color.Red)
                {
                    DisplayAlert("Error", "Please enter a valid Onsite Reference Contact", "OK");
                    return false;
                }
                if (string.IsNullOrEmpty(onsiteWorkedCompanyPhoneNo.Text))
                {
                    DisplayAlert("Error", "Please enter a value for Onsite Phone no", "OK");
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region toggle switch
        private void SwitchForOnsite_Toggled(object sender, ToggledEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
