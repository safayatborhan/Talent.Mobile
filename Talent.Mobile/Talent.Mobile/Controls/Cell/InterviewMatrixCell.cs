using DevenvExeBehaviors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Common;
using Talent.Mobile.CustomRenderer;
using Talent.Mobile.Models;
using Talent.Mobile.Models.InterviewModels;
using Talent.Mobile.Pages.User;
using Xamarin.Forms;

namespace Talent.Mobile.Controls.Cell
{
    class InterviewMatrixCell : ViewCell
    {
        public InterviewsModel interviewsModel = new InterviewsModel();

        private InterviewsModel model;
        private Models.CandidateDetails modelCandidateDetail = new CandidateDetails();

        private List<InterviewsModel> _items = new List<InterviewsModel>();
        public List<Models.CandidateDetails> _itemsCandidateDetail = new List<CandidateDetails>();

        public List<InterviewsModel> items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }
        public List<Models.CandidateDetails> itemsCandidateDetail
        {
            get
            {
                return _itemsCandidateDetail;
            }
            set
            {
                _itemsCandidateDetail = value;
                OnPropertyChanged();
            }
        }
        protected override void OnBindingContextChanged()
        {
            model = (InterviewsModel)BindingContext;
            base.OnBindingContextChanged();
            StackLayout stack = CreateEditLineItem();
            View = stack;
        }
        public InterviewMatrixCell(List<InterviewsModel> lstInterviewRoundsDetail, List<Models.CandidateDetails> candidateListForIm, InterviewsModel canditeInterviwsModel)
        {
            items = lstInterviewRoundsDetail;
            itemsCandidateDetail = candidateListForIm;
            interviewsModel = canditeInterviwsModel;
        }
        public StackLayout CreateEditLineItem()
        {
            StackLayout slUpcomingInterviewMatrixLayout = new StackLayout();
            try
            {

                Label lblCandidateName = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest=120 };
                Label lblRound = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest=40 };
                Label lblRemark = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black };
                lblCandidateName.Text = (from c in _itemsCandidateDetail where c.CandidateId == model.CandidateId select c.CandidateName).SingleOrDefault();
                
                lblRound.Text = model.Round.ToString();
                lblRemark.Text = model.OvarAllRemarks.Trim();

                slUpcomingInterviewMatrixLayout = new StackLayout
                {
                    Children = { lblCandidateName, lblRound, lblRemark },
                    Orientation = StackOrientation.Horizontal,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Padding = new Thickness(0, 0, 0, 0)
                };
            }
            catch (Exception ex)
            { }
            return slUpcomingInterviewMatrixLayout;
        }
    }
}
