using DevenvExeBehaviors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Context;
using Talent.Mobile.CustomRenderer;
using Talent.Mobile.Models.Models;
using Xamarin.Forms;

namespace Talent.Mobile.Pages.User
{
    public class Login : BasePage
    {
        public Login()
        {
            LoginLayout();
        }

        CustomEntryForLogin loginId = new CustomEntryForLogin();
        CustomEntryForLogin loginPassword = new CustomEntryForLogin();
        public void LoginLayout()
        {
            NavigationPage.SetHasNavigationBar(this, false);            
            Image imgBack = new Image { Source = "Home3.ico", HorizontalOptions = LayoutOptions.CenterAndExpand, HeightRequest=200, WidthRequest=150 };
            StackLayout sLoginImage = new StackLayout
            {
                Children = { imgBack },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(0, 0, 0, 20)
            };

            Label lblSignIn = new Label { Text = "Log In", FontSize=30, HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Black, FontAttributes = FontAttributes.Bold };
            StackLayout sLoginText = new StackLayout
            {
                Children = { lblSignIn },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(0, 0, 0, 40)
            };

            loginId = new CustomEntryForLogin { Placeholder = "ID", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor= Color.Red, TextColor=Color.White, AnchorX=50 };
            loginId.Behaviors.Add(new EmailValidatorBehavior());
            StackLayout sLoginId = new StackLayout
            {
                Children = { loginId },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(2, 0, 2, 8)
            };           
            loginPassword = new CustomEntryForLogin { IsPassword=true, Placeholder = "Password", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.FromHex("A9A9A9"), TextColor = Color.White };            
            StackLayout sLoginPassword = new StackLayout
            {
                Children = { loginPassword },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(2, 0, 2, 8)
            };

            Label lblLoginButton = new Label { Text = "", HorizontalOptions = LayoutOptions.Start, TextColor = Color.White, WidthRequest = 70, HeightRequest = 30 };
            Button btnLogin = new Button { Text = "Login", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.FromHex("4690FB"), TextColor = Color.White, BorderRadius = 10, WidthRequest = 150, HeightRequest = 40, FontAttributes = FontAttributes.Bold };
            StackLayout sLoginButton = new StackLayout
            {
                Children = { btnLogin },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(2, 0, 2, 8)
            };

            Label lblForResponse = new Label { Text = "", HorizontalOptions = LayoutOptions.StartAndExpand, TextColor = Color.Red };
            StackLayout sLblForResponse = new StackLayout
            {
                Children = { lblForResponse },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(0, 0, 0, 8)
            };

            Button btnLoginForgotPassword = new Button { Text = "Register here", HorizontalOptions = LayoutOptions.CenterAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), BorderRadius = 10, HeightRequest = 40, FontAttributes = FontAttributes.None };
            StackLayout sLoginForgotPassword = new StackLayout
            {
                Children = { btnLoginForgotPassword },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(2, 30, 2, 8)
            };

            StackLayout slLogin = new StackLayout
            {
                Children = { sLoginImage, sLoginText, sLoginId, sLoginPassword, sLoginButton, sLblForResponse, sLoginForgotPassword },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(20, 10, 20, 0),
                BackgroundColor = Color.White
            };

            ScrollView svMyProfile = new ScrollView { Content = slLogin };

            Content = svMyProfile;

            btnLoginForgotPassword.Clicked += (object sender, EventArgs e) => {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PushModalAsync(new Register());
                });
            };

            btnLogin.Clicked += (object sender, EventArgs e) => {
                if (Validate())
                {


                    try
                    {

                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            var result = await Service.GetLogin(loginId.Text, loginPassword.Text);
                            if (result != null && !string.IsNullOrEmpty(result))
                            {
                                UserModel response = JsonConvert.DeserializeObject<UserModel>(result);
                                
                                if (response.Email == loginId.Text)
                                {
                                    ACTContext.userId = response.Id;
                                    ACTContext.isLogin = true;
                                    //await Navigation.PushAsync(new Status());
                                    await Navigation.PushModalAsync(App.StatusPage());
                                    //if (ACTContext.menuItemNumber == 3)
                                    //{
                                    //    await Navigation.PushAsync(new WorkExperience());
                                    //}
                                    //else if (ACTContext.menuItemNumber == 4)
                                    //{
                                    //    await Navigation.PushAsync(new EducationDetails());
                                    //}
                                    //else if (ACTContext.menuItemNumber == 5)
                                    //{
                                    //    await Navigation.PushAsync(new InterviewDetails());
                                    //}
                                    //else if (ACTContext.menuItemNumber == 6)
                                    //{
                                    //    await Navigation.PushAsync(new InterviewMatrix());
                                    //}
                                    //else if (ACTContext.menuItemNumber == 7)
                                    //{
                                    //    await Navigation.PushAsync(new UploadDocuments());
                                    //}
                                    //else if (ACTContext.menuItemNumber == 8)
                                    //{
                                    //    await Navigation.PushAsync(new TestExam());
                                    //}
                                }
                                else
                                {
                                    lblForResponse.Text = "Login failed";
                                }
                            }
                            else
                            {
                                lblForResponse.Text = "Please enter valid username and password";
                            }
                        });
                    }
                    catch(Exception ex)
                    {
                        lblForResponse.Text = "Login failed";
                    }
                }
            };
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(loginId.Text))
            {
                DisplayAlert("Error", "Please enter a value for Login Id", "OK");
                return false;
            }
            if (loginId.TextColor == Color.Red)
            {
                DisplayAlert("Error", "Please enter a valid Login Id", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(loginPassword.Text))
            {
                DisplayAlert("Error", "Please enter a value for Password", "OK");
                return false;
            }                        
            return true;
        }

    }
}
