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
using Talent.Mobile.Droid.CustomRenderer;
using Talent.Mobile.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace Talent.Mobile.Droid.CustomRenderer
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.DarkGray);
                Control.SetTextColor(global::Android.Graphics.Color.Black);
                Control.SetCursorVisible(true);

                Control.SetHintTextColor(global::Android.Graphics.Color.White);
                //Control.SetShadowLayer(2, 2, 2, global::Android.Graphics.Color.DarkGray);
                //Control.SetHighlightColor(global::Android.Graphics.Color.DarkGray);
            }
        }
    }
}