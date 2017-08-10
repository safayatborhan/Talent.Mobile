using DevenvExeBehaviors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.CustomRenderer;
using Talent.Mobile.Models;
using Talent.Mobile.Models.InterviewModels;
using Talent.Mobile.Pages.User;
using Xamarin.Forms;

namespace Talent.Mobile.Controls.Cell
{
    class LineItemDetailCell : ViewCell
    {
        private InterviewsModel model;
        private Ratings modelRatingDetail = new Ratings();

        private List<InterviewsModel> _items = new List<InterviewsModel>();
        public List<Ratings> _itemsRatingDetail = new List<Ratings>();

        public int count = 0;

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
        public List<Ratings> itemsRatingDetail
        {
            get
            {
                return _itemsRatingDetail;
            }
            set
            {
                _itemsRatingDetail = value;
                OnPropertyChanged();
            }
        }
        protected override void OnBindingContextChanged()
        {
            try
            {
              //  model = (InterviewsModel)BindingContext;
                modelRatingDetail = (Ratings)BindingContext;
                //if (model.RatingList.Count > 0)
                //{
                //    modelRatingDetail = (Ratings)model.RatingList[0];
                //}
                //else
                //{
                //    modelRatingDetail = new Ratings();
                //}
                base.OnBindingContextChanged();
                StackLayout stack = CreateEditLineItem();
                View = stack;
            }
            catch(Exception ex)
            {

            }

        }
        public LineItemDetailCell(List<InterviewsModel> lstInterviewRoundsDetail, List<Ratings> ratingDetailList)
        {
            items = lstInterviewRoundsDetail;
            itemsRatingDetail = ratingDetailList;
        }
        public StackLayout CreateEditLineItem()
        {
            StackLayout slUpcomingInterviewMatrixLayout = new StackLayout();
            try
            {

                Label lblRoundNumber = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 20 };
                Label lblParameter = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 100 };
                Label lblRating = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 20 };
                Label lblRemark = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest=120 };
                Label lblIsSelected = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black };

                //lblCandidateName.Text = (from c in _itemsCandidateDetail where c.CandidateId == model.CandidateId select c.CandidateName).SingleOrDefault();
                //lblCandidateName.Text = model.CandidateId.ToString();
                
                lblRoundNumber.Text = (from c in _items where c.InterviewId == modelRatingDetail.InterviewId select c.Round.ToString()).SingleOrDefault();                
                lblParameter.Text = modelRatingDetail.LineItemDescription.ToString();
                lblRating.Text = modelRatingDetail.Rating1.ToString();
                lblRemark.Text = modelRatingDetail.Remarks.ToString();
                int selectedOrNot = int.Parse((from c in _items where c.Round == int.Parse(lblRoundNumber.Text) select c.IsSelected.ToString()).SingleOrDefault());
                if(selectedOrNot == 0)
                {
                    lblIsSelected.Text = "No";
                }
                if (selectedOrNot == 1)
                {
                    lblIsSelected.Text = "Yes";
                }
                //lblIsSelected.Text = (from c in _items where c.Round == int.Parse(lblRoundNumber.Text) select c.IsSelected.ToString()).SingleOrDefault();
                //lblParameter.Text = (from c in _items where c.InterviewId == modelRatingDetail.InterviewId select c.LineItemDescription).SingleOrDefault();
                //lblRemark.Text = model.OvarAllRemarks.Trim();


                slUpcomingInterviewMatrixLayout = new StackLayout
                {
                    Children = { lblRoundNumber, lblParameter, lblRating, lblRemark, lblIsSelected },
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
