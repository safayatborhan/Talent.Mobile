using System;
using System.Collections.Generic;
using System.Linq;

namespace Talent.Mobile.Models
{

    public class StatusModel
    {

        public bool? CandidateInfo { get; set; }
        public bool? EducationInfo { get; set; }
        public bool? WorkExpInfo { get; set; }
        public bool? UploadCV { get; set; }
        public bool? UploadPhoto { get; set; }
        public bool? Shortlisted { get; set; }
        public bool? WrittenTest { get; set; }
        public bool? WrittenTestResult { get; set; }
        public bool? AttendInterview { get; set; }
        public bool? InterviewResult { get; set; }
        public bool? BackgroundCheck { get; set; }
        public bool? AcceptOffer { get; set; }
        public bool? AppointmentOrder { get; set; }
    }


}