using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Mobile.Models
{
    public class SubjectTakensModel
    {
        public SubjectTakensModel()
        {
            QuestionsList = new List<QuestionsModel>();
            OptionsList = new List<OptionsModel>();
        }
        public int QuestionSetId { get; set; }
        public string QuestionSetNo { get; set; }
        public int ExamDuration { get; set; }
        public int BatchId { get; set; }
        public int CandidateId { get; set; }
        public double TotalTime { get; set; }
        //Questions
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionImage { get; set; }
        public int AnswerId { get; set; }

        //Options
        public int OptionId { get; set; }
        public string OptionText { get; set; }
        public string OptionImage { get; set; }

        public List<QuestionsModel> QuestionsList { get; set; }

        public int SelectedAnswerId { get; set; }
        public List<OptionsModel> OptionsList { get; set; }
    }

    public class QuestionsModel
    {
        public QuestionsModel()
        {
            OptionsList = new List<OptionsModel>();
        }
        public int QSequenceNo { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string QuestionImage { get; set; }
        public int AnswerId { get; set; }
        public List<OptionsModel> OptionsList { get; set; }
    }
    public class OptionsModel
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; }
        public string OptionImage { get; set; }
    }
}
