using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Mobile.Models
{
    public class Education
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> CollegeId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<int> DegreeId { get; set; }
        public Nullable<int> QualificationId { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public Nullable<decimal> Percentage { get; set; }
        public string ProjectInfo { get; set; }
    }
}
