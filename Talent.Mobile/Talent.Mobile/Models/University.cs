using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Mobile.Models.University
{
    public class Datum
    {
        public int id { get; set; }
        public string course_id { get; set; }
        public string specialization { get; set; }
        public string created_at { get; set; }
        public string created_by { get; set; }
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
        public string message { get; set; }
        public ResponseText responseText { get; set; }
    }

    public class UniversityModel
    {
        public int Id { get; set; }
        public string UniversityName { get; set; }
        public string UniversityType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> Pin { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
