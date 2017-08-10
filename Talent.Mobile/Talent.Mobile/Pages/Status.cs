using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Common;
using Talent.Mobile.Context;
using Talent.Mobile.Models;
using Talent.Mobile.Pages;
using Xamarin.Forms;

namespace Talent.Mobile
{
    public class Status : BasePage
    {
        public Status()
        {
            
            StatusModel statusInfo = new StatusModel();
            Device.BeginInvokeOnMainThread(async () =>
            {
                var statusList = await Service.GetStatus(ACTContext.userId);
                statusInfo = (StatusModel)JsonConvert.DeserializeObject<StatusModel>(statusList);
                StatusLayout(statusInfo);
            });
           
        }

        public void StatusLayout(StatusModel statusList)
        {
            NavigationPage.SetHasBackButton(this, false);
            Label lblTitle = new Label { Text = "Status", TextColor = Color.Black, FontSize = 26 };
            StackLayout slStatusTitle = new StackLayout { Children = { lblTitle }, HorizontalOptions = LayoutOptions.StartAndExpand, Padding = new Thickness(30, 5, 0, 5) };

            string imageSource = string.Empty;
            StatusModel statusInfo = new StatusModel();          

            if(statusList.CandidateInfo == null)
            {
                imageSource = Constant.ImagePath.Yellow;
            }
            else if(statusList.CandidateInfo == true)
            {
                imageSource = Constant.ImagePath.Green;
            }
            else
            {
                imageSource = Constant.ImagePath.Red;
            }

            Image imgCandidateInfo = new Image { Source = imageSource, WidthRequest = 40, HeightRequest = 40, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.CenterAndExpand };

            Label lblCandidateInfo = new Label { Text = "Candidate Info", TextColor = Color.Black, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };

            StackLayout slCandidateInfo = new StackLayout { Children = { imgCandidateInfo, lblCandidateInfo }, Orientation = StackOrientation.Horizontal };

            if (statusList.UploadPhoto == null)
            {
                imageSource = Constant.ImagePath.Yellow;
            }
            else if (statusList.UploadPhoto == true)
            {
                imageSource = Constant.ImagePath.Green;
            }
            else
            {
                imageSource = Constant.ImagePath.Red;
            }

            Image imgUploadPhoto = new Image { Source = imageSource, WidthRequest = 40, HeightRequest = 40, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.CenterAndExpand };

            Label lblUploadPhoto = new Label { Text = "Upload Photo", TextColor = Color.Black, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };

            StackLayout slUploadPhoto = new StackLayout { Children = { imgUploadPhoto, lblUploadPhoto }, Orientation = StackOrientation.Horizontal };

            if (statusList.UploadCV == null)
            {
                imageSource = Constant.ImagePath.Yellow;
            }
            else if (statusList.UploadCV == true)
            {
                imageSource = Constant.ImagePath.Green;
            }
            else
            {
                imageSource = Constant.ImagePath.Red;
            }

            Image imgUploadCV = new Image { Source = imageSource, WidthRequest = 40, HeightRequest = 40, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.CenterAndExpand };

            Label lblUploadCV = new Label { Text = "Upload CV", TextColor = Color.Black, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };

            StackLayout slUploadCV = new StackLayout { Children = { imgUploadCV, lblUploadCV }, Orientation = StackOrientation.Horizontal };

            if (statusList.EducationInfo == null)
            {
                imageSource = Constant.ImagePath.Yellow;
            }
            else if (statusList.EducationInfo == true)
            {
                imageSource = Constant.ImagePath.Green;
            }
            else
            {
                imageSource = Constant.ImagePath.Red;
            }

            Image imgEducationInfo = new Image { Source = imageSource, WidthRequest = 40, HeightRequest = 40, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.CenterAndExpand };

            Label lblEducationInfo = new Label { Text = "Education Info", TextColor = Color.Black, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };

            StackLayout slEducationInfo = new StackLayout { Children = { imgEducationInfo, lblEducationInfo }, Orientation = StackOrientation.Horizontal };

            if (statusList.WorkExpInfo == null)
            {
                imageSource = Constant.ImagePath.Yellow;
            }
            else if (statusList.WorkExpInfo == true)
            {
                imageSource = Constant.ImagePath.Green;
            }
            else
            {
                imageSource = Constant.ImagePath.Red;
            }

            Image imgWorkExpInfo = new Image { Source = imageSource, WidthRequest = 40, HeightRequest = 40, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.CenterAndExpand };

            Label lblWorkExpInfo = new Label { Text = "Work Experience Info", TextColor = Color.Black, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };

            StackLayout slWorkExpInfo = new StackLayout { Children = { imgWorkExpInfo, lblWorkExpInfo }, Orientation = StackOrientation.Horizontal };

            if (statusList.Shortlisted == null)
            {
                imageSource = Constant.ImagePath.Yellow;
            }
            else if (statusList.Shortlisted == true)
            {
                imageSource = Constant.ImagePath.Green;
            }
            else
            {
                imageSource = Constant.ImagePath.Red;
            }

            Image imgShortlisted = new Image { Source = imageSource, WidthRequest = 40, HeightRequest = 40, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.CenterAndExpand };

            Label lblShortlisted = new Label { Text = "Shortlisted", TextColor = Color.Black, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };

            StackLayout slShortlisted = new StackLayout { Children = { imgShortlisted, lblShortlisted }, Orientation = StackOrientation.Horizontal };

            if (statusList.WrittenTest == null)
            {
                imageSource = Constant.ImagePath.Yellow;
            }
            else if (statusList.WrittenTest == true)
            {
                imageSource = Constant.ImagePath.Green;
            }
            else
            {
                imageSource = Constant.ImagePath.Red;
            }

            Image imgWrittenTestAppeared = new Image { Source = imageSource, WidthRequest = 40, HeightRequest = 40, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.CenterAndExpand };

            Label lblWrittenTestAppeared = new Label { Text = "Written Test Appeared", TextColor = Color.Black, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };

            StackLayout slWrittenTestAppeared = new StackLayout { Children = { imgWrittenTestAppeared, lblWrittenTestAppeared }, Orientation = StackOrientation.Horizontal };

            if (statusList.WrittenTestResult == null)
            {
                imageSource = Constant.ImagePath.Yellow;
            }
            else if (statusList.WrittenTestResult == true)
            {
                imageSource = Constant.ImagePath.Green;
            }
            else
            {
                imageSource = Constant.ImagePath.Red;
            }

            Image imgWrittenTestStatus = new Image { Source = imageSource, WidthRequest = 40, HeightRequest = 40, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.CenterAndExpand };

            Label lblWrittenTestStatus = new Label { Text = "Written Test Status", TextColor = Color.Black, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };

            StackLayout slWrittenTestStatus = new StackLayout { Children = { imgWrittenTestStatus, lblWrittenTestStatus }, Orientation = StackOrientation.Horizontal };

            if (statusList.AttendInterview == null)
            {
                imageSource = Constant.ImagePath.Yellow;
            }
            else if (statusList.AttendInterview == true)
            {
                imageSource = Constant.ImagePath.Green;
            }
            else
            {
                imageSource = Constant.ImagePath.Red;
            }

            Image imgAttendInterview = new Image { Source = imageSource, WidthRequest = 40, HeightRequest = 40, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.CenterAndExpand };

            Label lblAttendInterview = new Label { Text = "Attend Interview", TextColor = Color.Black, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };

            StackLayout slAttendInterview = new StackLayout { Children = { imgAttendInterview, lblAttendInterview }, Orientation = StackOrientation.Horizontal };


            if (statusList.InterviewResult == null)
            {
                imageSource = Constant.ImagePath.Yellow;
            }
            else if (statusList.InterviewResult == true)
            {
                imageSource = Constant.ImagePath.Green;
            }
            else
            {
                imageSource = Constant.ImagePath.Red;
            }

            Image imgInterviewResult = new Image { Source = imageSource, WidthRequest = 40, HeightRequest = 40, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.CenterAndExpand };

            Label lblInterviewResult = new Label { Text = "Interview Result", TextColor = Color.Black, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };

            StackLayout slInterviewResult = new StackLayout { Children = { imgInterviewResult, lblInterviewResult }, Orientation = StackOrientation.Horizontal };


            if (statusList.BackgroundCheck == null)
            {
                imageSource = Constant.ImagePath.Yellow;
            }
            else if (statusList.BackgroundCheck == true)
            {
                imageSource = Constant.ImagePath.Green;
            }
            else
            {
                imageSource = Constant.ImagePath.Red;
            }

            Image imgBackgroundCheck = new Image { Source = imageSource, WidthRequest = 40, HeightRequest = 40, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.CenterAndExpand };

            Label lblBackgroundCheck = new Label { Text = "Background Check", TextColor = Color.Black, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };

            StackLayout slBackgroundCheck = new StackLayout { Children = { imgBackgroundCheck, lblBackgroundCheck }, Orientation = StackOrientation.Horizontal };


            if (statusList.AcceptOffer == null)
            {
                imageSource = Constant.ImagePath.Yellow;
            }
            else if (statusList.AcceptOffer == true)
            {
                imageSource = Constant.ImagePath.Green;
            }
            else
            {
                imageSource = Constant.ImagePath.Red;
            }

            Image imgAcceptOffer = new Image { Source = imageSource, WidthRequest = 40, HeightRequest = 40, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.CenterAndExpand };

            Label lblAcceptOffer = new Label { Text = "Accept Offer", TextColor = Color.Black, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };

            StackLayout slAcceptOffer = new StackLayout { Children = { imgAcceptOffer, lblAcceptOffer }, Orientation = StackOrientation.Horizontal };


            if (statusList.AppointmentOrder == null)
            {
                imageSource = Constant.ImagePath.Yellow;
            }
            else if (statusList.AppointmentOrder == true)
            {
                imageSource = Constant.ImagePath.Green;
            }
            else
            {
                imageSource = Constant.ImagePath.Red;
            }

            Image imgAppointmentOrder = new Image { Source = imageSource, WidthRequest = 40, HeightRequest = 40, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.CenterAndExpand };

            Label lblAppointmentOrder = new Label { Text = "Appointment Order", TextColor = Color.Black, HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };

            StackLayout slAppointmentOrder = new StackLayout { Children = { imgAppointmentOrder, lblAppointmentOrder }, Orientation = StackOrientation.Horizontal };
            
            StackLayout slStatus = new StackLayout { Children = { slStatusTitle, slCandidateInfo, slUploadPhoto, slUploadCV, slEducationInfo, slWorkExpInfo, slShortlisted, slWrittenTestAppeared, slWrittenTestStatus, slAttendInterview, slInterviewResult, slBackgroundCheck, slAcceptOffer, slAppointmentOrder }, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(50, 5, 0, 0) };

            ScrollView svStatus = new ScrollView { Content = slStatus, BackgroundColor = Color.White };

            Content = svStatus;       

        }
    }
}
