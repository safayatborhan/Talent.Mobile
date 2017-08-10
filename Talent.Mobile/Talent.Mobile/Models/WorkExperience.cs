using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Mobile.Models
{
    public class WorkExperienceModel
    {
        //public int Id { get; set; }
        //public int? UserId { get; set; }
        //public string Company { get; set; }
        //public string Role { get; set; }
        //public string Designation { get; set; }
        //public DateTime? FromDate { get; set; }
        //public DateTime? ToDate { get; set; }
        //public string ExperienceBrief { get; set; }
        //public string ReferenceContact { get; set; }
        //public byte? IsDelete { get; set; }
        //public decimal? ExperoenceYear { get; set; }

        //public Onsite onsite { get; set; }

        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }
        public string Designation { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public string ExperienceBrief { get; set; }
        public string ReferenceContact { get; set; }
        public Nullable<byte> IsDelete { get; set; }
        public Nullable<decimal> ExperoenceYear { get; set; }

        public Onsite onsite { get; set; }
    }
}
