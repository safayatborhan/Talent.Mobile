using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Mobile.Models
{
    public class QuestionSet
    {
        public int Id { get; set; }
        public string QuestionSetNo { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> DesignationId { get; set; }
        public Nullable<int> StreamId { get; set; }
        public Nullable<decimal> CutOffMarks { get; set; }
        public Nullable<System.TimeSpan> TimeTaken { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<byte> IsDelete { get; set; }
        public Nullable<int> Duration { get; set; }
    }
}
