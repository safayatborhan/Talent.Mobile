using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Mobile.Common;
using Talent.Mobile.Interface;
using Xamarin.Forms;

namespace Talent.Mobile.Pages
{
    public class MasterPage : MasterDetailPage
    {
        public MasterPage(ContentPage DetailPage)
        {
            HomeLayout(DetailPage);
        }
        public void HomeLayout(ContentPage DetailPage)
        {
            NavigationPage.SetHasBackButton(this, false);
            this.Master = new MenuList { };
            this.Detail = DetailPage;
        }


        
    }
}
