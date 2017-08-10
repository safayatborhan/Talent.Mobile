using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Mobile.Models.City
{
    public class Datum
    {
        public int id { get; set; }
        public string state_id { get; set; }
        public string district { get; set; }
    }

    public class ResponseText
    {
        public string token { get; set; }
        public string hiremee_id { get; set; }
        public List<Datum> data { get; set; }
    }

    public class RootObject
    {
        public string code { get; set; }
        public bool message { get; set; }
        public ResponseText responseText { get; set; }
    }
}
