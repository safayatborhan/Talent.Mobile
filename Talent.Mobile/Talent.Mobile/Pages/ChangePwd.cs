using DevenvExeBehaviors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.CustomRenderer;
using Talent.Mobile.Models.Models;
using Talent.Mobile.Context;
using Xamarin.Forms;

namespace Talent.Mobile.Pages.User
{
    class ChangePwd : BasePage
    {
        public UserModel userModel = new UserModel { };
        public ChangePwd()
        {

            //List<UserModel> educationList = new List<UserModel>();
            UserModel educationList = new UserModel { };
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await Service.GetUserById(ACTContext.userId);

                if (result != null)
                {
                    educationList = (UserModel)JsonConvert.DeserializeObject<UserModel>(result);
                    if(educationList!=null)
                    {
                        userModel = educationList;
                    }
                }
            });
            RegisterLayout(userModel);
        }

        //CustomEntryForLogin registerName = new CustomEntryForLogin();
        //CustomEntryForLogin registerMobile = new CustomEntryForLogin();
        //CustomEntryForLogin registerEmail = new CustomEntryForLogin();
        CustomEntryForLogin registerPassword = new CustomEntryForLogin();
        CustomEntryForLogin oldPwd = new CustomEntryForLogin();
        CustomEntryForLogin registerConfirmPassword = new CustomEntryForLogin();
        public void RegisterLayout(UserModel users)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            //Label lblRegisterName = new Label { Text = "Name", HorizontalOptions = LayoutOptions.Start, TextColor = Color.White, WidthRequest = 70, HeightRequest = 30 };

            Image imgBack = new Image { Source = "Home3.ico", HorizontalOptions = LayoutOptions.CenterAndExpand, HeightRequest = 100, WidthRequest = 50 };
            StackLayout sRegisterImage = new StackLayout
            {
                Children = { imgBack },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(0, 0, 0, 0)
            };

            Label lblRegister = new Label { Text = "Change Password", FontSize = 30, HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Black, FontAttributes = FontAttributes.Bold };
            StackLayout sRegisterText = new StackLayout
            {
                Children = { lblRegister },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(0, 0, 0, 10)
            };

            oldPwd = new CustomEntryForLogin { IsPassword = true, Placeholder = "Password", HorizontalOptions = LayoutOptions.FillAndExpand };
            //registerPassword.Behaviors.Add(new PasswordValidationBehavior());
            StackLayout oldRegisterPassword = new StackLayout
            {
                Children = { oldPwd },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(0, 0, 0, 8)
            };

            //Label lblRegisterPassword = new Label { Text = "Password", HorizontalOptions = LayoutOptions.Start, TextColor = Color.White, WidthRequest = 70, HeightRequest = 30 };
            registerPassword = new CustomEntryForLogin { IsPassword = true, Placeholder = "Password", HorizontalOptions = LayoutOptions.FillAndExpand };
            //registerPassword.Behaviors.Add(new PasswordValidationBehavior());
            StackLayout sRegisterPassword = new StackLayout
            {
                Children = { registerPassword },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(0, 0, 0, 8)
            };

            //Label lblRegisterConfirmPassword = new Label { Text = "Confirm Password", HorizontalOptions = LayoutOptions.Start, TextColor = Color.White, WidthRequest = 70, HeightRequest = 30 };
            registerConfirmPassword = new CustomEntryForLogin { IsPassword = true, Placeholder = "Confirm Password", HorizontalOptions = LayoutOptions.FillAndExpand };            
            StackLayout sRegisterConfirmPassword = new StackLayout
            {
                Children = { registerConfirmPassword },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(0, 0, 0, 8)
            };

            //Label lblRegisterButton = new Label { Text = "", HorizontalOptions = LayoutOptions.Start, TextColor = Color.White, WidthRequest = 70, HeightRequest = 30 };
            Button btnRegister = new Button { Text = "Register", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.FromHex("4690FB"), TextColor = Color.White, BorderRadius = 10, WidthRequest = 150, HeightRequest = 40, FontAttributes = FontAttributes.Bold };
            //btnRegister.Behaviors.Add(new ButtonBehaviour());
            StackLayout sRegisterButton = new StackLayout
            {
                Children = { btnRegister },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(0, 0, 0, 8)
            };

            Label lblForResponse = new Label { Text = "", HorizontalOptions = LayoutOptions.StartAndExpand, TextColor = Color.Red };
            StackLayout sLblForResponse = new StackLayout
            {
                Children = { lblForResponse },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(0, 0, 0, 8)
            };

            StackLayout sRegister = new StackLayout
            {
                Children = { sRegisterImage, sRegisterText, oldRegisterPassword, sRegisterPassword, sRegisterConfirmPassword, sRegisterButton, sLblForResponse },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(20, 10, 20, 0),
                BackgroundColor = Color.White
            };

            ScrollView svMyProfile = new ScrollView { Content = sRegister };

            Content = svMyProfile;

            UserModel userModel = new UserModel();

            //btnRegisterAlreadyHaveAccountButton.Clicked += (object sender, EventArgs e) => {
            //    Device.BeginInvokeOnMainThread(async () =>
            //    {
            //        await Navigation.PushAsync(new Login());
            //    });
            //};


            btnRegister.Clicked += (object sender, EventArgs e) =>
            {
                if (Validate())
                {
                    userModel.Id = ACTContext.userId;
                    userModel.Password = registerPassword.Text;
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var result = await Service.PostChangePwd(userModel);
                        int i = 0;
                        //foreach (var item in users)
                        //{
                            if (users.Email.Contains(userModel.Email))
                            {
                                i++;
                            }
                        //}
                        if (i > 0)
                        {
                            lblForResponse.Text = "Password Change Failed";
                        }
                        else
                        {
                            lblForResponse.Text = "Password Changed";
                            lblForResponse.TextColor = Color.Green;
                            registerPassword.Text = string.Empty;
                            registerConfirmPassword.Text = string.Empty;
                        }

                    });

                };
            };
        }

        private bool Validate()
        {

            if (string.IsNullOrEmpty(oldPwd.Text))
            {
                DisplayAlert("Error", "Please enter a value for Old Password", "OK");
                return false;
            }

            //if (oldPwd.Text != userModel.Password)
            //{
            //    DisplayAlert("Error", "Incorrect Old Password", "OK");
            //    return false;
            //}

            if (string.IsNullOrEmpty(registerPassword.Text))
            {
                DisplayAlert("Error", "Please enter a value for New Password", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(registerConfirmPassword.Text))
            {
                DisplayAlert("Error", "Please enter a value for Confirm New Password", "OK");
                return false;
            }
            if (registerPassword.Text != registerConfirmPassword.Text)
            {
                DisplayAlert("Error", "Password is not matching", "OK");
                return false;
            }
            return true;
        }
    }
}
