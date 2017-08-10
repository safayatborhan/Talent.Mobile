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
using Talent.Mobile.Droid.CustomRenderer;
using Talent.Mobile.CustomRenderer;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]
namespace Talent.Mobile.Droid.CustomRenderer
{
    public class CustomSwitchRenderer : SwitchRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Switch> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.TextOn = "Yes";
                Control.TextOff = "No";
                //Android.Graphics.Color colorOn = Color.Aqua.ToAndroid();
                //Android.Graphics.Color colorOff = Color.Gray.ToAndroid();
                //Android.Graphics.Color colorDisabled = Color.Gray.ToAndroid();
                //StateListDrawable drawable = new StateListDrawable();
                //drawable.AddState(new int[] { Android.Resource.Attribute.StateChecked }, new ColorDrawable(colorOn));
                //drawable.AddState(new int[] { -Android.Resource.Attribute.StateEnabled }, new ColorDrawable(colorDisabled));
                //drawable.AddState(new int[] { }, new ColorDrawable(colorOff));
                //Control.ThumbDrawable = drawable;
            }
        }
    }
}