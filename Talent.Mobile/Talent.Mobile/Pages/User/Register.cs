using DevenvExeBehaviors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.CustomRenderer;
using Talent.Mobile.Models.Models;
using Xamarin.Forms;

namespace Talent.Mobile.Pages.User
{
    class Register : BasePage
    {
        public Register()
        {
            List<UserModel> users = new List<UserModel>();
            Device.BeginInvokeOnMainThread(async () =>
            {
                var resultUsers = await Service.GetUsers();

                if (resultUsers != null)
                {
                    users = (List<UserModel>)JsonConvert.DeserializeObject<List<UserModel>>(resultUsers);
                    RegisterLayout(users);
                }

            });
            //RegisterLayout();
        }

        CustomEntryForLogin registerName = new CustomEntryForLogin();
        CustomEntryForLogin registerMobile = new CustomEntryForLogin();
        CustomEntryForLogin registerEmail = new CustomEntryForLogin();
        CustomEntryForLogin registerPassword = new CustomEntryForLogin();
        CustomEntryForLogin registerConfirmPassword = new CustomEntryForLogin();
        public void RegisterLayout(List<UserModel> users)
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

            Label lblRegister = new Label { Text = "Register", FontSize = 30, HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Black, FontAttributes = FontAttributes.Bold };
            StackLayout sRegisterText = new StackLayout
            {
                Children = { lblRegister },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(0, 0, 0, 10)
            };

            registerName = new CustomEntryForLogin { Placeholder = "Name", HorizontalOptions = LayoutOptions.FillAndExpand };
            StackLayout sRegisterName = new StackLayout
            {
                Children = { registerName },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(0, 0, 0, 8)
            };

            //Label lblRegisterMobile = new Label { Text = "Mobile", HorizontalOptions = LayoutOptions.Start, TextColor = Color.White, WidthRequest = 70, HeightRequest = 30 };
            registerMobile = new CustomEntryForLogin { Placeholder = "Mobile", HorizontalOptions = LayoutOptions.FillAndExpand };
            registerMobile.Behaviors.Add(new NumberValidationBehavior());
            StackLayout sRegisterMoble = new StackLayout
            {
                Children = { registerMobile },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(0, 0, 0, 8)
            };

            //Label lblRegisterEmail = new Label { Text = "Email", HorizontalOptions = LayoutOptions.Start, TextColor = Color.White, WidthRequest = 70, HeightRequest = 30 };

            registerEmail = new CustomEntryForLogin { Placeholder = "Email", HorizontalOptions = LayoutOptions.FillAndExpand };
            registerEmail.Behaviors.Add(new EmailValidatorBehavior());
            StackLayout sRegisterEmail = new StackLayout
            {
                Children = { registerEmail },
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

            Button btnRegisterAlreadyHaveAccountButton = new Button { Text = "Already have an account", HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("4690FB"), HeightRequest = 40, FontAttributes = FontAttributes.None };
            StackLayout sRegisterAlreadyHaveAccountButton = new StackLayout
            {
                Children = { btnRegisterAlreadyHaveAccountButton },
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(0, 15, 0, 8)
            };

            StackLayout sRegister = new StackLayout
            {
                Children = { sRegisterImage, sRegisterText, sRegisterName, sRegisterMoble, sRegisterEmail, sRegisterPassword, sRegisterConfirmPassword, sRegisterButton, sLblForResponse, sRegisterAlreadyHaveAccountButton },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(20, 10, 20, 0),
                BackgroundColor = Color.White
            };

            ScrollView svMyProfile = new ScrollView { Content = sRegister };

            Content = svMyProfile;

            UserModel userModel = new UserModel();

            btnRegisterAlreadyHaveAccountButton.Clicked += (object sender, EventArgs e) => {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PushAsync(new Login());
                });
            };


            btnRegister.Clicked += (object sender, EventArgs e) =>
            {
                if (Validate())
                {
                    userModel.FirstName = registerName.Text;
                    userModel.MiddleName = registerName.Text;
                    userModel.LastName = registerName.Text;
                    userModel.Gender = 1;
                    userModel.Mobile = registerMobile.Text;
                    userModel.Email = registerEmail.Text;
                    userModel.Password = registerPassword.Text;
                    userModel.Address1 = registerName.Text;
                    userModel.Address2 = registerName.Text;
                    userModel.City = registerName.Text;
                    userModel.StateId = 1;
                    userModel.CountryId = 1;
                    userModel.Pin = 1;
                    userModel.BioData = registerName.Text;
                    userModel.ProfileImage = registerName.Text;
                    userModel.CreatedDate = DateTime.Now;
                    userModel.ModifiedDate = DateTime.Now;
                    userModel.UserType = 1;
                    userModel.EmpId = 1;
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var result = await Service.PostRegister(userModel);
                        int i = 0;
                        foreach (var item in users)
                        {
                            if (item.Email.Contains(userModel.Email))
                            {
                                i++;
                            }
                        }
                        if (i > 0)
                        {
                            lblForResponse.Text = "Email address is already in use";
                        }
                        else
                        {
                            lblForResponse.Text = "Registration successfull";
                            lblForResponse.TextColor = Color.Green;
                            registerName.Text = string.Empty;
                            registerMobile.Text = string.Empty;
                            registerEmail.Text = string.Empty;
                            registerPassword.Text = string.Empty;
                            registerConfirmPassword.Text = string.Empty;
                        }

                    });

                };
            };
        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(registerName.Text))
            {
                DisplayAlert("Error", "Please enter a value for Name", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(registerMobile.Text))
            {
                DisplayAlert("Error", "Please enter a value for Mobile number", "OK");
                return false;
            }
            if (registerMobile.TextColor == Color.Red)
            {
                DisplayAlert("Error", "Please enter a valid Mobile number", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(registerEmail.Text))
            {
                DisplayAlert("Error", "Please enter a value for Email", "OK");
                return false;
            }
            if (registerEmail.TextColor == Color.Red)
            {
                DisplayAlert("Error", "Please enter a valid Email address", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(registerPassword.Text))
            {
                DisplayAlert("Error", "Please enter a value for Password", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(registerConfirmPassword.Text))
            {
                DisplayAlert("Error", "Please enter a value for Confirm Password", "OK");
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
