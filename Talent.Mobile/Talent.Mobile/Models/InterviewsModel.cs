using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Mobile.Models.InterviewModels
{
    public class InterviewsModel
    {
        public InterviewsModel()
        {
            //CandidateList = new Dictionary<int, string>();
            CandidateList = new List<Candidate>();
            LineItemList = new List<LineItem>();
            RatingList = new List<Ratings>();
            InterviewList = new List<InterviewsModel>();
            InterviewRoundList = new List<InterviewRounds>();
        }

        public List<InterviewsModel> InterviewList { get; set; }
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        //public Dictionary<int, string> CandidateList { get; set; }
        public List<Candidate> CandidateList = new List<Candidate>();

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string BioData { get; set; }
        public string ProfileImage { get; set; }
        public string QualificationName { get; set; }
        public decimal? ExperienceYear { get; set; }
        public List<LineItem> LineItemList { get; set; }
        public List<Ratings> RatingList { get; set; }

        public int InterviewId { get; set; }
        public int InterviewerUserId { get; set; }
        public int? Round { get; set; }
        public DateTime InterviewDate { get; set; }
        public string InterviewTime { get; set; }
        public string InterviewType { get; set; }
        public string Location { get; set; }
        public decimal? OvarAllRating { get; set; }
        public string OvarAllRemarks { get; set; }
        public byte? IsSelected { get; set; }
        public string InterviewerName { get; set; }

        public List<InterviewRounds> InterviewRoundList { get; set; }
        //public InterviewRounds InterviewRound { get; set; }

        public int InterviewRoundId { get; set; }
        public int IRCandidateId { get; set; }
        public string IRCandidateName { get; set; }
        public int IRRound { get; set; }
        public string IRRemarks { get; set; }
        public decimal IRAvgRating { get; set; }
        public decimal IRCombinedRating { get; set; }
        public byte IRSelected { get; set; }
        public byte IRMovedToNextRound { get; set; }

        //Line Item
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int Id { get; set; }
        public byte? IsDelete { get; set; }
        public string LineItemDescription { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class CandidateDetail
    {
        public int UserId { get; set; }
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public int InterviewId { get; set; }
    }

    public class Ratings
    {
        // public Ratings();

        public int RatingId { get; set; }
        public int? InterviewId { get; set; }
        public byte? IsDelete { get; set; }
        public int? LineItemId { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public decimal? Rating1 { get; set; }
        public string Remarks { get; set; }
        public string LineItemDescription { get; set; }
    }

    public class InterviewRounds
    {
        public int Id { get; set; }
        public Nullable<int> CandidateId { get; set; }
        public Nullable<int> Round { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> AvgRating { get; set; }
        public Nullable<decimal> CombinedRating { get; set; }
        public Nullable<byte> Selected { get; set; }
        public Nullable<byte> MovedToNextRound { get; set; }
        public string CandidateName { get; set; }
    }
}
