using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Talent.Mobile.Pages.Master
{
    class MasterPageForStatus : MasterDetailPage
    {
        public MasterPageForStatus()
        {
            NavigationPage.SetHasBackButton(this, false);

            HomeLayout();
        }
        public void HomeLayout()
        {
            this.Master = new MenuList { };
            this.Detail = new Status();
        }
    }

}
