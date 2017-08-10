using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Mobile.Models.College
{
    public class ResponseText
    {
        public string token { get; set; }
        public string hiremee_id { get; set; }
        public List<College> college { get; set; }
    }

    public class RootObject
    {
        public string code { get; set; }
        public string message { get; set; }
        public ResponseText responseText { get; set; }
    }

    public class College
    {
        public int id { get; set; }
        public string name { get; set; }

        //added later
        public int Id { get; set; }
        public Nullable<int> UniversityId { get; set; }
        public string CollegeName { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> Pin { get; set; }
        public string ContactPerson { get; set; }
        public string CPPhone { get; set; }
        public string CPEmailId { get; set; }
        public Nullable<int> PlacementOfficerId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
