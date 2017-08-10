using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Talent.Mobile.Controls.Cell
{
    public class TextItemCell : ViewCell
    {
        public TextItemCell()
        {
            var CategoryLayout = CategoryStack();

            View = CategoryLayout;
        }

        StackLayout CategoryStack()
        {

            Label lblText = new Label();
            lblText.SetBinding(Label.TextProperty, "item");
            lblText.TextColor = Color.White;

            StackLayout cellLayout = new StackLayout
            {
                Padding = new Thickness(5),
                Orientation = StackOrientation.Horizontal
            };

            StackLayout itemTextLayout = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Spacing = 0,
                Children = {
                            lblText
                           }
            };

            cellLayout.Children.Add(itemTextLayout);

            return cellLayout;
        }
    }
}
