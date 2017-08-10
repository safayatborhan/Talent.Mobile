using Dropbox.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Talent.Mobile.Common
{
    public class Constant
    {

        //public static string LocalhostURL = "http://dev.hiremee.co.in/api/";

        //public static string LocalhostURL = "http://192.168.0.103:97/api/";
        //public static string LocalhostURL = "http://192.168.0.101:97/api/";
        //public static string LocalhostURL = "http://192.168.56.1:97/api/";
        public static string LocalhostURL = "http://talentapi.azurewebsites.net/api/";

        public static int UserId = 1;

        public static int InterviewId;

        public static DropboxClient dropboxClient = new DropboxClient("Hc5wwumhyiYAAAAAAAAKDR_FZydsM9in5_-32azCquClRuXfaaS_L6hGrJ7cNguW");

        //public static string LocalhostURL = "http://192.168.0.101:89/api/";
        public class APIInfo
        {
            public static string token = "LTOKEN99SGAp5On9p7Tz6YAZ";
            public static string hiremee_id = "HC000015";
            public static string tabletype = "state";
        }

        public static Color ButtonColor = Color.FromHex("#08AE9E");
        /// <summary>
        /// Constant Role.
        /// </summary>

        /// <summary>
        /// Images constant.
        /// </summary>
        public class ImagePath
        {
            public static string RightArrow = "aerrow.png";
            public static string DropDownArrow = "dropdown_arrow.png";
            public static string DownArrow = "down_arrow.png";
            public static string Red = "Red.png";
            public static string Green = "Green.png";
            public static string Yellow = "Yellow.png";
            public static string SlideOutMenu = "left_menu.png";
        }

        public class FieldType
        {
            public static string City = "City";
            public static string State = "State";
            public static string University = "University";
            public static string College = "College";
            public static string CourseType = "CourseType";
            public static string Specialization = "Specialization";
            public static string BackLogs = "BackLogs";
            public static string YearOfCompletion = "YearOfCompletion";
        }


    }
}
