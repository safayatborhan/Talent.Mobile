using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Common;
using Talent.Mobile.Models;
using Talent.Mobile.Models.College;
using Xamarin.Forms;

namespace Talent.Mobile.Controls.Cell
{
    class EducationCell : ViewCell
    {
        private Education model;
        private College modelCollege;
        private Qualification modelQualification;

        private List<Education> _items = new List<Education>();
        private List<College> _collegeItems = new List<College>();
        private List<Qualification> _qualificationItems = new List<Qualification>();
        public List<Education> items
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
        public List<College> collegeItems
        {
            get
            {
                return _collegeItems;
            }
            set
            {
                _collegeItems = value;
                OnPropertyChanged();
            }
        }
        public List<Qualification> qualificationItems
        {
            get
            {
                return _qualificationItems;
            }
            set
            {
                _qualificationItems = value;
                OnPropertyChanged();
            }
        }

        protected override void OnBindingContextChanged()
        {
            model = (Education)BindingContext;
            //modelCollege = (College)BindingContext;
            //modelQualification = (Qualification)BindingContext;
            base.OnBindingContextChanged();
            StackLayout stack = CreateEditEducation();
            View = stack;
        }

        public StackLayout CreateEditEducation()
        {
            List<College> college = new List<College>();
            List<College> collgeList = new List<College>();
            string resultCollege = "";
            Device.BeginInvokeOnMainThread(async () =>
            {
                resultCollege = await Service.GetCollgeNames();
            });
            StackLayout slUpcomingEducationLayout = new StackLayout();
            try
            {
                Label lblEducationUniversity = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 180 };
                Label lblEducationQualification = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 180 };
                Label lblEducationPercentage = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 65 };
                Image imgRemove = new Image { Source = "delete.png", BackgroundColor = Color.Transparent };
                lblEducationUniversity.Text = (from x in collegeItems where x.Id == model.CollegeId select x.CollegeName).SingleOrDefault();
                lblEducationQualification.Text = (from x in qualificationItems where x.Id == model.QualificationId select x.QualificationName).SingleOrDefault();


                lblEducationPercentage.Text = model.Percentage.ToString();

                var RemoveTapGestureRecognizer = new TapGestureRecognizer();
                RemoveTapGestureRecognizer.NumberOfTapsRequired = 1; // single-tap

                imgRemove.GestureRecognizers.Add(RemoveTapGestureRecognizer);
                imgRemove.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("."));

                slUpcomingEducationLayout = new StackLayout
                {
                    Children = { lblEducationUniversity, lblEducationQualification, lblEducationPercentage, imgRemove },
                    Orientation = StackOrientation.Horizontal,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Padding = new Thickness(0, 0, 0, 0)
                };

                RemoveTapGestureRecognizer.Tapped += (s, e) =>
                {
                    try
                    {
                        lblEducationUniversity.IsVisible = false;
                        lblEducationQualification.IsVisible = false;
                        lblEducationPercentage.IsVisible = false;
                        imgRemove.IsVisible = false;
                        var result = Service.DeleteEducationDetailById(model.Id);
                        items.Remove(model);
                        var listView = (ListView)Parent;
                        listView.ItemsSource = items;
                        listView.HeightRequest = 50 * items.Count;
                        listView.ItemTemplate = new DataTemplate(() => new EducationCell(items,collegeItems,qualificationItems));
                    }
                    catch (Exception ex)
                    {

                    }
                };
            }
            catch (Exception ex)
            { }
            return slUpcomingEducationLayout;
        }

        public EducationCell(List<Education> lstEducationItems,List<College> lstCollges, List<Qualification> lstQualification)
        {
            items = lstEducationItems;
            collegeItems = lstCollges;
            qualificationItems = lstQualification;
        }
        public EducationCell(List<Education> lstEducationItems)
        {
            items = lstEducationItems;
        }
    }
}
