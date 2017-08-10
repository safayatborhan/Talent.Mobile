using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Models;
using Xamarin.Forms;

namespace Talent.Mobile.Controls.Cell
{
    class WorkExperienceCell : ViewCell
    {
        private WorkExperienceModel model;
        private List<WorkExperienceModel> _items = new List<WorkExperienceModel>();
        public List<WorkExperienceModel> items
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
            model = (WorkExperienceModel)BindingContext;
            base.OnBindingContextChanged();
            StackLayout stack = CreateEditWorkExperience();
            View = stack;
        }

        public StackLayout CreateEditWorkExperience()
        {            
            StackLayout slUpcomingWorkExperienceLayout = new StackLayout();
            StackLayout slBoxView = new StackLayout();
            StackLayout slWorkExperienceLayout = new StackLayout();
            try
            {

                Label lblWorkExperienceCompnay = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 125 };
                Label lblWorkExperienceRole = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 125 };
                Label lblWorkExperienceDesignation = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 125 };
                Image imgRemove = new Image { Source = "delete.png", BackgroundColor = Color.Transparent };

                var RemoveTapGestureRecognizer = new TapGestureRecognizer();
                RemoveTapGestureRecognizer.NumberOfTapsRequired = 1; // single-tap

                imgRemove.GestureRecognizers.Add(RemoveTapGestureRecognizer);
                imgRemove.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("."));

                lblWorkExperienceCompnay.Text = model.Company;
                lblWorkExperienceRole.Text = model.Role;
                lblWorkExperienceDesignation.Text = model.Designation;
                //CustomEntryForLogin rating = new CustomEntryForLogin { Placeholder = "Rating", HorizontalOptions = LayoutOptions.FillAndExpand, HeightRequest = 30 };

                slUpcomingWorkExperienceLayout = new StackLayout
                {
                    Children = { lblWorkExperienceCompnay, lblWorkExperienceRole,lblWorkExperienceDesignation, imgRemove },
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
                slWorkExperienceLayout = new StackLayout
                {
                    Children = { slUpcomingWorkExperienceLayout },
                    Orientation = StackOrientation.Horizontal,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Padding = new Thickness(0, 0, 0, 0)
                };

                RemoveTapGestureRecognizer.Tapped += (s, e) =>
                {
                    try
                    {
                        lblWorkExperienceCompnay.IsVisible = false;
                        lblWorkExperienceRole.IsVisible = false;
                        lblWorkExperienceDesignation.IsVisible = false;
                        imgRemove.IsVisible = false;
                        var result = Service.DeleteWorkExperienceById(model.Id);
                        items.Remove(model);
                        var listView = (ListView)Parent;
                        listView.ItemsSource = items;
                        listView.HeightRequest = 50 * items.Count;
                        listView.ItemTemplate = new DataTemplate(() => new WorkExperienceCell(items));
                    }
                    catch (Exception ex)
                    {

                    }
                };

            }
            catch (Exception ex)
            { }
            return slWorkExperienceLayout;
        }

        public WorkExperienceCell(List<WorkExperienceModel> lstWorkExperienceItems)
        {
            items = lstWorkExperienceItems;
        }
    }
}
