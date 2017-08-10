using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Models.InterviewModels;

namespace Talent.Mobile.Context
{
    public class ACTContext
    {
        public static bool isLogin = false;
        public static List<string> StateList;
        public static List<string> CityList;

        public static List<Ratings> ratingDetailsListContext = new List<Ratings>();

        public static int userId;
        public static int interviewerId = 50;

        public static int candidateId;
        public static int batchId;

        public static int menuItemNumber;
    }
}
