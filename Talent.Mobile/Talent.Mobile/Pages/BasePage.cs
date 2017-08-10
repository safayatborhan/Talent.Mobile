using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Common;
using Talent.Mobile.Context;
using Talent.Mobile.Interface;
using Xamarin.Forms;

namespace Talent.Mobile.Pages
{
    public class BasePage : ContentPage
    {
        public BasePage()
        {
            LoadingInit();
        }

        ActivityIndicator LoadingIndicator;
        private void LoadingInit()
        {
            LoadingIndicator = new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Color = Color.Black,
                IsVisible = false
            };
            this.Content = new StackLayout
            {
                Children = {
                    LoadingIndicator,
                },
                BackgroundColor = Color.White,
            };
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            ToolbarItems.Clear();
            BindToolbar();
            try
            {
                bool isNetworkAvailable = DependencyService.Get<INetworkOperation>().IsInternetConnectionAvailable();

                if (!isNetworkAvailable)
                {
                    DisplayAlert("Connection", "Please check your internet connection.", Messages.Ok);                   
                }
            }
            catch (Exception ex)
            {
            }
        }


        public void BindToolbar()
        {
            List<ToolbarItem> lstToolbarItem = new List<ToolbarItem>();

            ExtendedToolbarItem menuToolbarItem = new ExtendedToolbarItem("Menu", Constant.ImagePath.SlideOutMenu, ToolbarItemOrder.Primary, LeftMenu);

            lstToolbarItem.Add(menuToolbarItem);

            foreach (ToolbarItem item in lstToolbarItem)
            {
                this.ToolbarItems.Add(item);
            }
        }

        private void LeftMenu()
        {
            try
            {
                string ViewName = (ParentView.ParentView).GetType().Name;
                if ((ParentView.ParentView).GetType().Name != "NavigationPage")
                    ((MasterDetailPage)(ParentView).ParentView).IsPresented = !((MasterDetailPage)(ParentView).ParentView).IsPresented;
                else
                    ((MasterDetailPage)ParentView).IsPresented = !((MasterDetailPage)ParentView).IsPresented;
            }
            catch (Exception ex)
            {

            }
        }

        //private void Login()
        //{
        //    Navigation.PushAsync(App.LoginPage());
        //}

        //private void Logout()
        //{
        //    ACTContext.isLogin = false;
        //    Navigation.PushAsync(App.LoginPage());
        //}
        protected override void OnDisappearing()
        {
            GC.Collect();
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }
    }
}
