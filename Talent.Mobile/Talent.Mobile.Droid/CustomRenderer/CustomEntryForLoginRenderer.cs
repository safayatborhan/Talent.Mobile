using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Talent.Mobile.CustomRenderer;
using Talent.Mobile.Droid.CustomRenderer;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntryForLogin), typeof(CustomEntryForLoginRenderer))]
namespace Talent.Mobile.Droid.CustomRenderer
{
    class CustomEntryForLoginRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TextSize = 14;
                Control.SetBackgroundColor(global::Android.Graphics.Color.Gray);
                Control.TextScaleX = 0;
                //Control.SetBackgroundColor(global::Android.Graphics.Color.ParseColor("A9A9A9"));
                Control.SetTextColor(global::Android.Graphics.Color.White);
                //Control.SetTextColor(global::Android.Graphics.Color.ParseColor("#646968"));
                Control.SetCursorVisible(true);
                Control.SetHintTextColor(global::Android.Graphics.Color.White);
                //Control.SetShadowLayer(2, 2, 2, global::Android.Graphics.Color.DarkGray);
                //Control.SetHighlightColor(global::Android.Graphics.Color.DarkGray);
            }
        }
    }
}