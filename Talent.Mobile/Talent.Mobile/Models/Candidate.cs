using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Mobile.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string FirstName { get; set; }
        public Nullable<System.DateTime> DateOfsubmission { get; set; }
        public Nullable<byte> Shortlisted { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> WrittenTestAppeared { get; set; }
        public Nullable<bool> WrittenTestStatus { get; set; }
        public Nullable<bool> DocumentVerificationPass { get; set; }
        public string InterviewStatus { get; set; }
        public Nullable<int> HoldTimeInDays { get; set; }
        public Nullable<bool> BGPass { get; set; }
        public Nullable<bool> OfferLettterSent { get; set; }
        public Nullable<bool> OfferAccept { get; set; }
        public string BGDeclaration { get; set; }
        public Nullable<bool> MedicalCheckup { get; set; }
        public Nullable<System.DateTime> DOJ { get; set; }
        public string EVDeclaration { get; set; }
        public Nullable<byte> IsDelete { get; set; }
        public Nullable<decimal> ExperienceYear { get; set; }

        public decimal? OvarAllRating { get; set; }
        public string OvarAllRemarks { get; set; }

        public List<LineItem> LineItemList { get; set; }
    }
}
