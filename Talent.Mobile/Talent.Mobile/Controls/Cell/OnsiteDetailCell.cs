using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Models;
using Xamarin.Forms;

namespace Talent.Mobile.Controls.Cell
{
    class OnsiteDetailCell : ViewCell
    {
        private Onsite model;
        private List<Onsite> _items = new List<Onsite>();
        public List<Onsite> items
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
            model = (Onsite)BindingContext;
            base.OnBindingContextChanged();
            StackLayout stack = CreateEditOnsiteDetail();
            View = stack;
        }

        public StackLayout CreateEditOnsiteDetail()
        {
            StackLayout slUpcomingOnsiteDetailLayout = new StackLayout();
            StackLayout slBoxView = new StackLayout();
            StackLayout slOnsiteDetailLayout = new StackLayout();
            try
            {

                Label lblOnsiteDetails = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 125 };
                Label lblOnsiteDetailsContact = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 125 };
                Label lblOnsiteDetailLocation = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 125 };
                lblOnsiteDetails.Text = model.OnsiteDetails;
                lblOnsiteDetailsContact.Text = model.ContactDetails.ToString();
                lblOnsiteDetailLocation.Text = model.Location;
                //CustomEntryForLogin rating = new CustomEntryForLogin { Placeholder = "Rating", HorizontalOptions = LayoutOptions.FillAndExpand, HeightRequest = 30 };

                slUpcomingOnsiteDetailLayout = new StackLayout
                {
                    Children = { lblOnsiteDetails, lblOnsiteDetailsContact, lblOnsiteDetailLocation },
                    Orientation = StackOrientation.Horizontal,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                BoxView separator1 = new BoxView() { Color = Color.Gray, HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand };
                slBoxView = new StackLayout
                {
                    Children = { separator1 },
                    Orientation = StackOrientation.Horizontal,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Padding = new Thickness(0, 0, 0, 0)
                };
                slOnsiteDetailLayout = new StackLayout
                {
                    Children = { slUpcomingOnsiteDetailLayout },
                    Orientation = StackOrientation.Horizontal,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Padding = new Thickness(0, 0, 0, 0)
                };
            }
            catch (Exception ex)
            { }
            return slOnsiteDetailLayout;
        }

        public OnsiteDetailCell(List<Onsite> lstOnsiteDetailItems)
        {
            items = lstOnsiteDetailItems;
        }
    }
}
