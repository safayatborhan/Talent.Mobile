using DevenvExeBehaviors;
using ImageCircle.Forms.Plugin.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Controls.Cell;
using Talent.Mobile.CustomRenderer;
using Talent.Mobile.Models;
using Talent.Mobile.Models.College;
using Talent.Mobile.Models.University;
using Xamarin.Forms;
using EonianXamarinLabs;
using Talent.Mobile.ViewModels;
using Talent.Mobile.Models.InterviewModels;
using Talent.Mobile.Context;
using Talent.Mobile.Pages.User;

namespace Talent.Mobile.Pages
{
    class TestExam : BasePage
    {
        #region initialize
        StackLayout sLblTestScreenTimeRemaining;
        int examRemainigHour;
        int examReamainingMinute;
        int examRemainingSecond;

        int unAnswered = 0;

        StackLayout slblQuestion = new StackLayout();
        BindableRadioGroup bRadioAnswerOptions = new BindableRadioGroup();
        StackLayout sbtnSubmitAnswer = new StackLayout();
        StackLayout sbtnSubmitAnswer2 = new StackLayout();
        Label lblTestScreenTimeReamaining = new Label { HorizontalOptions = LayoutOptions.EndAndExpand, TextColor = Color.FromHex("7AD169"), FontSize = 13, FontAttributes = FontAttributes.Bold };

        int countQuestion = 0;
        string _selectedRadio;

        Button btnStartTest = new Button { Text = "Start test", HorizontalOptions = LayoutOptions.CenterAndExpand, BackgroundColor = Color.FromHex("4690FB"), TextColor = Color.White, BorderRadius = 10, WidthRequest = 150, FontAttributes = FontAttributes.Bold };
        #endregion

        #region constructor
        public TestExam()
        {
            SubjectTakensModel subjectTakenModel = new SubjectTakensModel();

            InterviewsModel interviewsModel = new InterviewsModel();
            List<Batch> batchModel = new List<Batch>();
            Device.BeginInvokeOnMainThread(async () =>
            {
                var getCandidateIdByUserId = await Service.GetCandidateDetail(1);  //here should be ACTContext.userId
                
                if (getCandidateIdByUserId != null)
                {
                    interviewsModel = JsonConvert.DeserializeObject<InterviewsModel>(getCandidateIdByUserId);
                    //batchModel = (List<Batch>)JsonConvert.DeserializeObject<List<Batch>>(getBatchList);
                    ACTContext.candidateId = interviewsModel.CandidateId;
                    //ACTContext.batchId = (from c in batchModel where c.CollegeId == interviewsModel.id select c.Id).SingleOrDefault();

                    subjectTakenModel.CandidateId = ACTContext.candidateId;
                    var getBatchList = await Service.GetBatch(ACTContext.candidateId);
                    subjectTakenModel.BatchId = int.Parse(getBatchList);  //need to know how batch id works
                }
            });

            List <QuestionSet> questions = new List<QuestionSet>();
            
            
            Device.BeginInvokeOnMainThread(async () =>
            {
                var resultSubjectTakenModel = await Service.QuetionsListByQuetionSetId(subjectTakenModel);
                var resultQuestions = await Service.GetQuestionSet();

                if (resultQuestions != null && resultSubjectTakenModel != null)
                {
                    subjectTakenModel = JsonConvert.DeserializeObject<SubjectTakensModel>(resultSubjectTakenModel);
                    questions = (List<QuestionSet>)JsonConvert.DeserializeObject<List<QuestionSet>>(resultQuestions);
                    TestExamLayout(subjectTakenModel);
                    examRemainigHour = subjectTakenModel.ExamDuration / 60;
                    examReamainingMinute = subjectTakenModel.ExamDuration % 60;
                    examRemainingSecond = 1;
                }
            });
        }
        #endregion

        public void TestExamLayout(SubjectTakensModel subjectTakenModel)
        {
            if (ACTContext.isLogin == true)
            {
                #region header text
                Label lblTestScreenHeaderText = new Label { Text = "Mock Test", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.White, FontSize = 20, FontAttributes = FontAttributes.Bold };
                StackLayout sLblTestScreenHeaderText = new StackLayout
                {
                    Children = { lblTestScreenHeaderText },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 50, 0, 0)
                };
                #endregion

                #region start button
                StackLayout sbtnStartTest = new StackLayout
                {
                    Children = { btnStartTest },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(20, 10, 2, 8)
                };
                btnStartTest.Clicked += (object sender, EventArgs e) =>
                {
                    btnStartTest.IsVisible = false;
                    slblQuestion.IsVisible = true;
                    bRadioAnswerOptions.IsVisible = true;
                    sbtnSubmitAnswer.IsVisible = true;
                    sbtnSubmitAnswer2.IsVisible = true;
                };
                #endregion

                #region time remaining
                if (countQuestion == 0)
                {

                    Device.StartTimer(new TimeSpan(0, 0, 1), () =>
                    {
                        if (btnStartTest.IsVisible == false)
                        {
                            if (examRemainingSecond <= 0 && examReamainingMinute <= 0 && examRemainigHour <= 0)
                            {
                                return false;
                            }
                            if (examRemainingSecond <= 0 && examReamainingMinute <= 0)
                            {
                                examRemainingSecond = 61;
                                examReamainingMinute = 61;
                                lblTestScreenTimeReamaining.Text = "Time remaining : " + --examRemainigHour + " Hours " + --examReamainingMinute + " Minutes " + --examRemainingSecond + " Seconds";
                                return true;
                            }
                            if (examRemainingSecond <= 0)
                            {
                                examRemainingSecond = 61;
                                lblTestScreenTimeReamaining.Text = "Time remaining : " + examRemainigHour + " Hours " + --examReamainingMinute + " Minutes " + --examRemainingSecond + " Seconds";
                                return true;
                            }


                            lblTestScreenTimeReamaining.Text = "Time remaining : " + examRemainigHour + " Hours " + examReamainingMinute + " Minutes " + --examRemainingSecond + " Seconds";
                        }
                        return true;

                    });
                    sLblTestScreenTimeRemaining = new StackLayout
                    {
                        Children = { lblTestScreenTimeReamaining },
                        Orientation = StackOrientation.Horizontal,
                        Padding = new Thickness(0, 30, 0, 10)
                    };
                }
                #endregion

                #region Question

                List<QuestionsModel> setOfQuestions = new List<QuestionsModel>();
                setOfQuestions = subjectTakenModel.QuestionsList;

                Label lblQuestion = new Label { HorizontalOptions = LayoutOptions.StartAndExpand, TextColor = Color.White, FontSize = 15, FontAttributes = FontAttributes.None };
                if (setOfQuestions.Count >= countQuestion + 1)
                {
                    lblQuestion.Text = setOfQuestions[countQuestion].QuestionText;
                }
                else
                {
                    lblQuestion.Text = "";
                }
                slblQuestion = new StackLayout
                {
                    Children = { lblQuestion },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(20, 10, 20, 0)
                };

                #endregion

                #region answers            
                CustomRadioButton radioAnswerOption1 = new CustomRadioButton();
                CustomRadioButton radioAnswerOption2 = new CustomRadioButton();
                CustomRadioButton radioAnswerOption3 = new CustomRadioButton();
                CustomRadioButton radioAnswerOption4 = new CustomRadioButton();
                if (setOfQuestions.Count >= countQuestion + 1)
                {
                    radioAnswerOption1.Text = setOfQuestions[countQuestion].OptionsList[0].OptionText;
                    radioAnswerOption2.Text = setOfQuestions[countQuestion].OptionsList[1].OptionText;
                    radioAnswerOption3.Text = setOfQuestions[countQuestion].OptionsList[2].OptionText;
                    radioAnswerOption4.Text = setOfQuestions[countQuestion].OptionsList[3].OptionText;

                    bRadioAnswerOptions = new BindableRadioGroup()
                    {
                        Orientation = StackOrientation.Vertical,
                        Padding = new Thickness(20, 10, 20, 5)
                    };
                    bRadioAnswerOptions.ItemsSource = new[]
                    {
                 radioAnswerOption1.Text,
                 radioAnswerOption2.Text,
                 radioAnswerOption3.Text,
                 radioAnswerOption4.Text
            };
                    bRadioAnswerOptions.CheckedChanged += BRadioAnswerOptions_CheckedChanged;
                }
                else
                {
                    radioAnswerOption1.Text = "";
                    radioAnswerOption2.Text = "";
                    radioAnswerOption3.Text = "";
                    radioAnswerOption4.Text = "";

                    slblQuestion.IsVisible = false;
                    bRadioAnswerOptions.IsVisible = false;
                    sbtnSubmitAnswer.IsVisible = false;
                    sbtnSubmitAnswer2.IsVisible = false;
                }


                #endregion

                #region submit button
                Button btnSubmitAnswer = new Button { Text = "Next", HorizontalOptions = LayoutOptions.StartAndExpand, BackgroundColor = Color.FromHex("4690FB"), TextColor = Color.White, BorderRadius = 10, WidthRequest = 100, FontAttributes = FontAttributes.Bold };
                Button btnCancelExam = new Button { Text = "End test", HorizontalOptions = LayoutOptions.CenterAndExpand, BackgroundColor = Color.FromHex("4690FB"), TextColor = Color.White, BorderRadius = 10, WidthRequest = 100, FontAttributes = FontAttributes.Bold };
                Button btnBackToPreviousQuestion = new Button { Text = "Previous", HorizontalOptions = LayoutOptions.EndAndExpand, BackgroundColor = Color.FromHex("4690FB"), TextColor = Color.White, BorderRadius = 10, WidthRequest = 100, FontAttributes = FontAttributes.Bold };
                sbtnSubmitAnswer = new StackLayout
                {
                    Children = { btnSubmitAnswer, btnBackToPreviousQuestion },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(20, 10, 2, 8)
                };
                sbtnSubmitAnswer2 = new StackLayout
                {
                    Children = { btnCancelExam },
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(0, 5, 0, 5)
                };
                if (countQuestion == 0)
                {
                    btnBackToPreviousQuestion.IsEnabled = false;
                }
                btnBackToPreviousQuestion.Clicked += (object sender, EventArgs e) =>
                {
                    if (countQuestion > 1)
                    {
                        countQuestion--;
                        TestExamLayout(subjectTakenModel);
                    }
                };
                btnSubmitAnswer.Clicked += (object sender, EventArgs e) =>
                {
                    subjectTakenModel.CandidateId = 1;
                    subjectTakenModel.BatchId = 6;
                    subjectTakenModel.QuestionId = setOfQuestions[countQuestion].QuestionId;
                    if (_selectedRadio == "first")
                    {
                        subjectTakenModel.SelectedAnswerId = setOfQuestions[countQuestion].OptionsList[0].OptionId;
                    }
                    else if (_selectedRadio == "second")
                    {
                        subjectTakenModel.SelectedAnswerId = setOfQuestions[countQuestion].OptionsList[1].OptionId;
                    }
                    else if (_selectedRadio == "third")
                    {
                        subjectTakenModel.SelectedAnswerId = setOfQuestions[countQuestion].OptionsList[2].OptionId;
                    }
                    else if (_selectedRadio == "fourth")
                    {
                        subjectTakenModel.SelectedAnswerId = setOfQuestions[countQuestion].OptionsList[3].OptionId;
                    }
                    else
                    {
                        subjectTakenModel.SelectedAnswerId = 0;
                        unAnswered++;
                    }
                    _selectedRadio = "";

                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        var result = await Service.SaveAnswer(subjectTakenModel);
                    });
                    countQuestion++;
                    TestExamLayout(subjectTakenModel);
                };
                #endregion

                #region stack and content layouts

                Label lblAfterExamResponse = new Label { HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.FromHex("7AD169"), FontSize = 17, FontAttributes = FontAttributes.None };

                lblAfterExamResponse.IsVisible = false;

                if (btnStartTest.IsVisible == true)
                {
                    slblQuestion.IsVisible = false;
                    bRadioAnswerOptions.IsVisible = false;
                    sbtnSubmitAnswer.IsVisible = false;
                    sbtnSubmitAnswer2.IsVisible = false;
                }

                if (slblQuestion.IsVisible == false && bRadioAnswerOptions.IsVisible == false && btnStartTest.IsVisible == false)
                {
                    sbtnSubmitAnswer.IsVisible = false;
                    sbtnSubmitAnswer2.IsVisible = false;
                    lblAfterExamResponse.IsVisible = true;
                    string result = "";
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        result = await Service.CalculateCandidateTestResult(subjectTakenModel);

                        lblTestScreenTimeReamaining.IsVisible = false;
                        TimeSpan finishedTime = new TimeSpan(examRemainigHour, examReamainingMinute, examRemainingSecond);
                        TimeSpan startedTime = new TimeSpan(subjectTakenModel.ExamDuration / 60, subjectTakenModel.ExamDuration / 60, 0);
                        lblAfterExamResponse.Text =
                        "Test finished. Thank you\n\nRight answers : "
                        + result.ToString()
                        + "\n\nWrong answers : " + (subjectTakenModel.QuestionsList.Count - int.Parse(result)) + "\n\nUnattended : " + (unAnswered++) + "\n\nPercentage : "
                        + ((int.Parse(result) * 100) / subjectTakenModel.QuestionsList.Count) +
                        "%\n\nTime taken : " + startedTime.Subtract(finishedTime);

                    });

                }

                StackLayout slTestScreen = new StackLayout
                {
                    Children = { sLblTestScreenHeaderText, sbtnStartTest,
                    sLblTestScreenTimeRemaining, slblQuestion ,bRadioAnswerOptions,
                    sbtnSubmitAnswer, sbtnSubmitAnswer2, lblAfterExamResponse },
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Padding = new Thickness(20, 0, 20, 0),
                    BackgroundColor = Color.Gray
                };

                ScrollView svTestScreenDetails = new ScrollView { Content = slTestScreen };

                Content = svTestScreenDetails;
                #endregion

            }
            else
            {
                Navigation.PushModalAsync(new Login());
            }
        }
        #region radio button group check changed event
        private void BRadioAnswerOptions_CheckedChanged(object sender, int e)
        {
            var radio = sender as CustomRadioButton;

            if (radio == null || radio.Id == -1)
            {
                return;
            }
            if(radio.Id == 0)
            {
                _selectedRadio = "first";
            }
            if (radio.Id == 1)
            {
                _selectedRadio = "second";
            }
            if (radio.Id == 2)
            {
                _selectedRadio = "third";
            }
            if (radio.Id == 3)
            {
                _selectedRadio = "fourth";
            }
        }
        #endregion
    }
}
