using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Common;
using Xamarin.Forms;

namespace Talent.Mobile.Controls
{
    class Seperator : BoxView
    {
        public Seperator()
        {
            Color = Color.Gray;
            HeightRequest = 0.5;

            LineSeperatorView = new BoxView()
            {
                Color = LayoutHelper.SeperatorColor,
                WidthRequest = 100,
                HeightRequest = 1
            };
        }
        public BoxView LineSeperatorView { get; set; }
    }
}
