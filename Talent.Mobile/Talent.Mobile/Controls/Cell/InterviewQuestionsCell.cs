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
    class InterviewQuestionsCell : ViewCell
    {
        private InterviewSet model;

        private List<InterviewSet> _items = new List<InterviewSet>();
        public List<InterviewSet> items
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
            model = (InterviewSet)BindingContext;
            //modelCollege = (College)BindingContext;
            //modelQualification = (Qualification)BindingContext;
            base.OnBindingContextChanged();
            StackLayout stack = DisplayIV();
            View = stack;
        }

        public StackLayout DisplayIV()
        {
            List<InterviewSet> college = new List<InterviewSet>();
            //List<College> collgeList = new List<College>();
            //string resultCollege = "";
            //Device.BeginInvokeOnMainThread(async () =>
            //{
            //    resultCollege = await Service.GetCollgeNames();
            //});
            StackLayout slUpcomingEducationLayout = new StackLayout();
            try
            {
                Label lblQ = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 180 };
                Label lblA = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 180 };
                //Label lblEducationPercentage = new Label { HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black, WidthRequest = 65 };
                //Image imgRemove = new Image { Source = "delete.png", BackgroundColor = Color.Transparent };
                lblQ.Text = (from x in items where x.Id == model.Id select x.IVSetQuestion).SingleOrDefault();
                lblA.Text = (from x in items where x.Id == model.Id select x.IVSetAnswer).SingleOrDefault();


                //lblEducationPercentage.Text = model.Percentage.ToString();

                //var RemoveTapGestureRecognizer = new TapGestureRecognizer();
                //RemoveTapGestureRecognizer.NumberOfTapsRequired = 1; // single-tap

                //imgRemove.GestureRecognizers.Add(RemoveTapGestureRecognizer);
                //imgRemove.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding("."));

                slUpcomingEducationLayout = new StackLayout
                {
                    Children = { lblQ, lblA },
                    Orientation = StackOrientation.Horizontal,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Padding = new Thickness(0, 0, 0, 0)
                };

                //RemoveTapGestureRecognizer.Tapped += (s, e) =>
                //{
                //    try
                //    {
                //        lblEducationUniversity.IsVisible = false;
                //        lblEducationQualification.IsVisible = false;
                //        lblEducationPercentage.IsVisible = false;
                //        imgRemove.IsVisible = false;
                //        var result = Service.DeleteEducationDetailById(model.Id);
                //        items.Remove(model);
                //        var listView = (ListView)Parent;
                //        listView.ItemsSource = items;
                //        listView.HeightRequest = 50 * items.Count;
                //        listView.ItemTemplate = new DataTemplate(() => new EducationCell(items, collegeItems, qualificationItems));
                //    }
                //    catch (Exception ex)
                //    {

                //    }
                //};
            }
            catch (Exception ex)
            { }
            return slUpcomingEducationLayout;
        }

        public InterviewQuestionsCell(List<InterviewSet> lstEducationItems)
        {
            items = lstEducationItems;
        }
        //public EducationCell(List<Education> lstEducationItems)
        //{
        //    items = lstEducationItems;
        //}
    }
}
