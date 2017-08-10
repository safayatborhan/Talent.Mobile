using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Talent.Mobile.Pages.User;
using Talent.Mobile.Pages;
using Talent.Mobile.Pages.Master;

namespace Talent.Mobile
{
    public class App : Application
    {
        static NavigationPage navPage;


        public App()
        {
            MainPage = LoginPage();
        }

        public static Page LoginPage()
        {
            navPage = new NavigationPage(new Login());
            return navPage;
        }

        public static Page StatusPage()
        {
            navPage = new NavigationPage(new MasterPageForStatus());
            return navPage;
        }

        public static Page WorkExperiencePage()
        {
            navPage = new NavigationPage(new MasterPage(new WorkExperience()));
            return navPage;
        }

        public static Page EducationDetailPage()
        {
            navPage = new NavigationPage(new MasterPage(new EducationDetails()));
            return navPage;
        }

        public static Page InterviewDetailPage()
        {
            navPage = new NavigationPage(new MasterPage(new InterviewDetails()));
            return navPage;
        }

        public static Page InterviewMatrixPage()
        {
            navPage = new NavigationPage(new MasterPage(new InterviewMatrix()));
            return navPage;
        }

        public static Page UploadCVPage()
        {
            navPage = new NavigationPage(new MasterPage(new UploadDocuments()));
            return navPage;
        }

        public static Page TestPage()
        {
            navPage = new NavigationPage(new MasterPage(new TestExam()));
            return navPage;
        }

        public static Page ViewIVQuestions()
        {
            navPage = new NavigationPage(new MasterPage(new ViewIVQuestions()));
            return navPage;
        }
    }
}
