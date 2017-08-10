using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Mobile.Models.Course
{
    public class Coursetype
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class ResponseText
    {
        public string token { get; set; }
        public string hiremee_id { get; set; }
        public List<Coursetype> coursetype { get; set; }
    }

    public class RootObject
    {
        public string code { get; set; }
        public string message { get; set; }
        public ResponseText responseText { get; set; }
    }
}
