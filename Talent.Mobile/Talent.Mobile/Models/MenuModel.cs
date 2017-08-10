using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Mobile.Models
{
    public class MenuModel
    {
        public string item { get; set; }
        public int itemNumber { get; set; }
        public string imagePath { get; set; }

        public static List<MenuModel> ListCategoryMenu()
        {
            List<MenuModel> lstMenuItem = new List<MenuModel>();

            lstMenuItem.Add(new MenuModel { item = "Login", itemNumber = 1 });
            lstMenuItem.Add(new MenuModel { item = "Status", itemNumber = 2 });
            lstMenuItem.Add(new MenuModel { item = "Work Experience", itemNumber = 3 });
            lstMenuItem.Add(new MenuModel { item = "Education Detail", itemNumber = 4 });
            lstMenuItem.Add(new MenuModel { item = "Interview Detail", itemNumber = 5 });
            lstMenuItem.Add(new MenuModel { item = "Interview Matrix", itemNumber = 6 });
            lstMenuItem.Add(new MenuModel { item = "Upload Document", itemNumber = 7 });
            lstMenuItem.Add(new MenuModel { item = "Test", itemNumber = 8 });
            lstMenuItem.Add(new MenuModel { item = "Logout", itemNumber = 9 });
            lstMenuItem.Add(new MenuModel { item = "View IVQuestions", itemNumber = 10 });
            return lstMenuItem;
        }
    }
}
