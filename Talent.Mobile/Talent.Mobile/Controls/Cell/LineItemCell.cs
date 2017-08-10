using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Context;
using Talent.Mobile.Controls;
using Talent.Mobile.CustomRenderer;
using Talent.Mobile.Models;
using Talent.Mobile.Models.InterviewModels;
using Xamarin.Forms;

namespace Talent.Mobile.Pages.User
{
    class LineItemCell : ViewCell
    {
        bool iterateAgain = true;
        ACTContext context = new ACTContext();
        Ratings ratingDetails = new Ratings();

        CustomEntryForGeneralPurpose remark = new CustomEntryForGeneralPurpose();
        CustomEntryForGeneralPurpose rating = new CustomEntryForGeneralPurpose();

        private LineItem model;
        public RatingDetails ratingDetail = new RatingDetails();

        private List<LineItem> _items = new List<LineItem>();
        public List<LineItem> items
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
        protected override void OnBindingContextChanged()
        {
            model = (LineItem)BindingContext;
            base.OnBindingContextChanged();
            StackLayout stack = CreateEditLineItem();
            View = stack;
        }
        public LineItemCell(List<LineItem> lstLineItems)
        {
            items = lstLineItems;
        }
        public StackLayout CreateEditLineItem()
        {
            StackLayout slUpcomingLineItemLayout = new StackLayout();
            try
            {

                Label lblLineItemTitle = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 80 };
                lblLineItemTitle.Text = model.LineItemDescription;
                rating = new CustomEntryForGeneralPurpose { Placeholder = "Rating", HorizontalOptions = LayoutOptions.FillAndExpand, Keyboard = Keyboard.Numeric };
                rating.TextChanged += Rating_TextChanged;
                //rating.Text = "0";
                remark = new CustomEntryForGeneralPurpose { Placeholder = "Remark", HorizontalOptions = LayoutOptions.FillAndExpand };
                
                remark.TextChanged += Remark_TextChanged;
                //remark.Text = "";
                StackLayout slLineItemTitle = new StackLayout
                {
                    Children = { lblLineItemTitle },
                    Padding = new Thickness(0, 8, 0, 0)
                };
                slUpcomingLineItemLayout = new StackLayout
                {
                    Children = { slLineItemTitle, rating, remark },
                    Orientation = StackOrientation.Horizontal,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                remark.IsEnabled = false;
                //Ratings ratingDetails = new Ratings()
                //{
                //    RatingId = model.Id,
                //    LineItemId = model.Id,
                //    Rating1 = int.Parse(rating.Text),
                //    Remarks = remark.Text
                //};
                //ACTContext.ratingDetailsListContext.Add(ratingDetails);

            }
            catch (Exception ex)
            { }
            return slUpcomingLineItemLayout;
        }

        private void Remark_TextChanged(object sender, TextChangedEventArgs e)
        {
            //throw new NotImplementedException();
            ratingDetails = new Ratings
            {
                RatingId = model.Id,
                LineItemId = model.Id,
                Remarks = e.NewTextValue
            };
            foreach (var item in ACTContext.ratingDetailsListContext.Where(w => w.RatingId == ratingDetails.RatingId))
            {
                item.Remarks = e.NewTextValue;
            }
        }

        
        private void Rating_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string _text = rating.Text;
                //if (e.NewTextValue != e.OldTextValue + ".")
                if (e.NewTextValue != null)
                {
                    //if (_text.Length > 2)
                    //{
                    //    _text = _text.Remove(_text.Length - 1);
                    //    rating.Text = _text;
                    //    iterateAgain = false;
                    //    return;
                    //}
                    if (iterateAgain == true)
                    {
                        ratingDetails = new Ratings
                        {
                            RatingId = model.Id,
                            LineItemId = model.Id,
                            Rating1 = decimal.Parse(e.NewTextValue)
                        };
                        if ((ACTContext.ratingDetailsListContext.Select(x => x.RatingId).Contains(ratingDetails.RatingId)))
                        {
                            foreach (var item in ACTContext.ratingDetailsListContext.Where(w => w.RatingId == ratingDetails.RatingId))
                            {
                                item.Rating1 = Decimal.Parse(e.NewTextValue);
                            }
                        }
                        else
                        {
                            ACTContext.ratingDetailsListContext.Add(ratingDetails);
                        }

                        remark.IsEnabled = true;
                        iterateAgain = true;
                    }

                }

                //foreach (var item in ACTContext.ratingDetailsListContext.Where(w => w.RatingId == ratingDetails.RatingId))
                //{
                //    item.Rating1 = decimal.Parse(e.NewTextValue);
                //}
            }
            catch(Exception ex)
            {

            }

        }
    }
}
