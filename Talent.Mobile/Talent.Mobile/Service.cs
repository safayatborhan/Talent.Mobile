using Talent.Mobile.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Models;
using Xamarin.Forms;
using Talent.Mobile.Models.Models;
using Talent.Mobile.Models.InterviewModels;

namespace Talent.Mobile
{
    public class Service
    {
        #region get methods
        public static Task<string> GetLogin(string username, string password)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "user/GetLogin?username=" + username + "&password=" + password).Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }
        }

        public static Task<string> GetDegrees()
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "Common/GetDegrees").Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    UserModel um = new UserModel();
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> GetStreams()
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "Common/GetStreams").Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    UserModel um = new UserModel();
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> GetWorkExpById(int userId)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "WorkExperience/GetAll?userId=" + userId).Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> GetOnsiteInfo(int userId)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "WorkExperience/GetOnsiteById?userId=" + userId).Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> GetStatus(int userId)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "Status/GetStatus?userId=" + userId).Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

      }

        public static Task<string> GetEducationDetails(int userId)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "Education/GetAll?userId=" + userId).Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> GetCollegeName(int collgeId)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "College/GetCollgeById?collegeId=1").Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> GetStates()
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.PostAsync(Constant.LocalhostURL + "mastertables", multipartFormDataContent).Result;
                        responseStr.SetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }
        }

        public static Task<string> GetCities()
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.PostAsync(Constant.LocalhostURL + "district", multipartFormDataContent).Result;
                        responseStr.SetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }
        }


        public static Task<string> GetUniversities()
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "College/GetUniversities").Result;
                        responseStr.SetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }
        }

        public static Task<string> GetColleges()
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "Common/GetColleges").Result;
                        responseStr.SetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }
        }

        public static Task<string> GetQualifications()
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "Common/GetQualifications").Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    UserModel um = new UserModel();
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> GetCollgeNames()
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "Common/GetColleges").Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    UserModel um = new UserModel();
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> GetUsers()
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "Common/GetUsers").Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    UserModel um = new UserModel();
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> GetCandidate(int interviewerId)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        //var result = client.GetAsync(Constant.LocalhostURL + "Interview/GetCandidateDetail?userId=" + userId).Result;
                        var result = client.GetAsync(Constant.LocalhostURL + "Interview/GetCandidateList?id=" + interviewerId).Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    UserModel um = new UserModel();
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> GetCandidateDetail(int userId)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        //var result = client.GetAsync(Constant.LocalhostURL + "Interview/GetCandidateDetail?userId=" + userId).Result;
                        var result = client.GetAsync(Constant.LocalhostURL + "Interview/GetCandidateDetail?userId=" + userId).Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    UserModel um = new UserModel();
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> GetBatch(int cid)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "SubjectTaken/GetBatch?cid="+ cid).Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    UserModel um = new UserModel();
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> GetCandidateInformation(int candidateId, int interviewerId)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "Interview/GetInterviewById?id=" + candidateId + "&interviewerId=" + interviewerId).Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> GetCourses()
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.PostAsync(Constant.LocalhostURL + "mastertables", multipartFormDataContent).Result;
                        responseStr.SetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }
        }


        public static Task<string> GetSpecializations()
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.PostAsync(Constant.LocalhostURL + "speclization", multipartFormDataContent).Result;
                        responseStr.SetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }
        }

        public static Task<string> GetInterviewRoundsList()
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "Interview/GetInterviewRoundsList").Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> GetCandidateListForIM()
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "Interview/GetCandidateListForIM").Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    UserModel um = new UserModel();
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> GetCandidateDetailWithInterview(int candidateId, int riId)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "Interview/GetCandidateDetailWithInterview?candidateId=" + candidateId + "&riId="+riId).Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> GetQuestionSet()
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "QuestionSet/GetQuestionSetList").Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }


        public static Task<string> GetDepartments()
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "Common/GetAllDepartmentsList").Result;
                        responseStr.SetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }
        }
        public static Task<string> GetDesignations()
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "Common/GetAllDesignationsList").Result;
                        responseStr.SetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }
        }
        //public static Task<string> GetStreams()
        //{
        //    var responseStr = new TaskCompletionSource<string>();
        //    using (var client = new HttpClient())
        //    {
        //        try
        //        {
        //            using (var multipartFormDataContent = new MultipartFormDataContent())
        //            {
        //                var result = client.GetAsync(Constant.LocalhostURL + "QuestionSet/GetStreamlist").Result;
        //                responseStr.SetResult(result.Content.ReadAsStringAsync().Result);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            responseStr.TrySetResult(ex.Message.ToString());
        //        }
        //        return responseStr.Task;
        //    }
        //}


        #endregion


        #region post methods
        public static Task<string> PostWorkExperience(WorkExperienceModel workExperience)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(workExperience), Encoding.UTF8, "application/json");
                    var result = client.PostAsync(Constant.LocalhostURL + "WorkExperience/Post/", stringContent).Result;
                    responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> PostDocument(DocumentModel documentModel)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(documentModel), Encoding.UTF8, "application/json");
                    var result = client.PostAsync(Constant.LocalhostURL + "Document/SaveDocument/", stringContent).Result;
                    responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> PostInterviewDetails(InterviewsModel interview)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(interview), Encoding.UTF8, "application/json");
                    var result = client.PostAsync(Constant.LocalhostURL + "Interview/SaveInterview/", stringContent).Result;
                    responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> PostEducationDetail(Education education)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(education), Encoding.UTF8, "application/json");
                    var result = client.PostAsync(Constant.LocalhostURL + "Education/Post/", stringContent).Result;
                    responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> PostRegister(UserModel userModel)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                    var result = client.PostAsync(Constant.LocalhostURL + "user/Post/", stringContent).Result;
                    responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> PostInterviewRound(InterviewsModel objInterview)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(objInterview), Encoding.UTF8, "application/json");
                    var result = client.PostAsync(Constant.LocalhostURL + "Interview/SaveInterviewRound/", stringContent).Result;
                    responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> PostLineItem(LineItem lineItem)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(lineItem), Encoding.UTF8, "application/json");
                    var result = client.PostAsync(Constant.LocalhostURL + "Interview/SaveLineItem/", stringContent).Result;
                    responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }


        public static Task<string> GetIvQuestionsDetails(InterviewQuestions interrviewQues)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.GetAsync(Constant.LocalhostURL + "InterviewQuestions/GetQuestionsList?desigId=" + interrviewQues.desigId + "&streamId=" + interrviewQues.streamId).Result;
                        responseStr.SetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }
        }


        public static Task<string> PostIvQuestionsDetails(InterviewQuestions interrviewQues)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(interrviewQues), Encoding.UTF8, "application/json");
                    //var result = client.PostAsync(Constant.LocalhostURL + "InterviewQuestions/DisplayQuestions/", stringContent).Result;
                    //var result = client.GetAsync(Constant.LocalhostURL + "InterviewQuestions/GetQuestionsList?desigId="+interrviewQues.desigId+ "&streamId="+interrviewQues.streamId).Result;
                    var result = client.GetAsync(Constant.LocalhostURL + "InterviewQuestions/GetAll").Result;
                    responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> SaveInterviewRound(InterviewsModel objInterview)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(objInterview), Encoding.UTF8, "application/json");
                    var result = client.PostAsync(Constant.LocalhostURL + "Interview/SaveInterviewRound/", stringContent).Result;
                    responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> QuetionsListByQuetionSetId(SubjectTakensModel subjectTakenModel)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(subjectTakenModel), Encoding.UTF8, "application/json");
                    var result = client.PostAsync(Constant.LocalhostURL + "SubjectTaken/QuetionsListByQuetionSetId/", stringContent).Result;
                    responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> SaveAnswer(SubjectTakensModel obj)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                    var result = client.PostAsync(Constant.LocalhostURL + "SubjectTaken/SaveAnswer/", stringContent).Result;
                    responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        
        public static Task<string> CalculateCandidateTestResult(SubjectTakensModel obj)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    var stringContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                    var result = client.PostAsync(Constant.LocalhostURL + "SubjectTaken/CalculateCandidateTestResult/", stringContent).Result;
                    responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                }
                catch (Exception ex)
                {
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }
        #endregion



        #region delete methods
        public static Task<string> DeleteWorkExperienceById(int workExperienceId)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.DeleteAsync(Constant.LocalhostURL + "WorkExperience/Delete?workExperienceId="+workExperienceId).Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    UserModel um = new UserModel();
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }

        public static Task<string> DeleteEducationDetailById(int educationId)
        {
            var responseStr = new TaskCompletionSource<string>();
            using (var client = new HttpClient())
            {
                try
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {
                        var result = client.DeleteAsync(Constant.LocalhostURL + "Education/Delete?educationId=" + educationId).Result;
                        responseStr.TrySetResult(result.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    UserModel um = new UserModel();
                    responseStr.TrySetResult(ex.Message.ToString());
                }
                return responseStr.Task;
            }

        }
        #endregion
    }
}
