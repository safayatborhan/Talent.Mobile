using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Common;
using Talent.Mobile.Controls.Cell;
using Talent.Mobile.Models;
using Xamarin.Forms;

namespace Talent.Mobile.Pages
{
    public class MenuList : ContentPage
    {
        ListView listMenu;

        public MenuList()
        {            
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            Title = "Talent";
            //Icon = Constant.ImagePath.SlideOutMenu;
            //Icon = "";

            listMenu = new ListView { RowHeight = 40, BackgroundColor = Color.FromHex("#5B5A5F") };

            listMenu.ItemsSource = MenuModel.ListCategoryMenu();
            listMenu.ItemTemplate = new DataTemplate(() => new TextItemCell());

            listMenu.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem == null) return;
                MenuModel objMenu = (MenuModel)e.SelectedItem;

                if (objMenu.itemNumber == 1)
                {
                    ((ListView)sender).SelectedItem = null;
                    Navigation.PushModalAsync(App.LoginPage());
                }
                else if (objMenu.itemNumber == 2)
                {
                    ((ListView)sender).SelectedItem = null;
                    Navigation.PushModalAsync(App.StatusPage());
                }
                else if (objMenu.itemNumber == 3)
                {
                    ((ListView)sender).SelectedItem = null;
                    ((MasterDetailPage)ParentView).IsPresented = !((MasterDetailPage)ParentView).IsPresented;
                    Navigation.PushAsync(App.WorkExperiencePage());
                }
                else if (objMenu.itemNumber == 4)
                {
                    ((ListView)sender).SelectedItem = null;
                    //Navigation.PushModalAsync(App.EducationDetailPage());
                    ((MasterDetailPage)ParentView).IsPresented = !((MasterDetailPage)ParentView).IsPresented;
                    Navigation.PushAsync(App.EducationDetailPage());
                }
                else if (objMenu.itemNumber == 5)
                {
                    ((ListView)sender).SelectedItem = null;
                    ((MasterDetailPage)ParentView).IsPresented = !((MasterDetailPage)ParentView).IsPresented;
                    Navigation.PushAsync(App.InterviewDetailPage());
                }
                else if (objMenu.itemNumber == 6)
                {
                    ((ListView)sender).SelectedItem = null;
                    ((MasterDetailPage)ParentView).IsPresented = !((MasterDetailPage)ParentView).IsPresented;
                    Navigation.PushAsync(App.InterviewMatrixPage());
                }
                else if (objMenu.itemNumber == 7)
                {
                    ((ListView)sender).SelectedItem = null;
                    ((MasterDetailPage)ParentView).IsPresented = !((MasterDetailPage)ParentView).IsPresented;
                    Navigation.PushAsync(App.UploadCVPage());
                }
                else if (objMenu.itemNumber == 8)
                {
                    ((ListView)sender).SelectedItem = null;
                    ((MasterDetailPage)ParentView).IsPresented = !((MasterDetailPage)ParentView).IsPresented;
                    Navigation.PushAsync(App.TestPage());
                }
                else if (objMenu.itemNumber == 9)
                {
                    Context.ACTContext.isLogin = false;
                    ((ListView)sender).SelectedItem = null;
                    Navigation.PushModalAsync(App.LoginPage());
                }
                else if (objMenu.itemNumber == 10)
                {
                    ((ListView)sender).SelectedItem = null;
                    ((MasterDetailPage)ParentView).IsPresented = !((MasterDetailPage)ParentView).IsPresented;
                    Navigation.PushAsync(App.ViewIVQuestions());
                }
            };

            Content = new StackLayout
            {
                BackgroundColor = LayoutHelper.MenuSliderBackgroundColor,
				 Children = {
                      listMenu
                    }
            };
        }
    }
}
