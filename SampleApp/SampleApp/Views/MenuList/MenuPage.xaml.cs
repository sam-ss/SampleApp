using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views
{
	 
	public partial class MenuPage : MasterDetailPage
    {
		public MenuPage ()
		{
			InitializeComponent ();
            var menuPage = new MenuListPage();
            menuPage.OnMenuSelect = (categoryPage) =>
            {
                Detail = new NavigationPage(categoryPage)
                {
                    //BarBackgroundColor = Color.FromHex("#8999A6"),
                    //BarTextColor = Color.White
                };
                IsPresented = false;
            };
            Master = menuPage;

            Detail = new NavigationPage(new EmployeeListPage())
            {
                //BarBackgroundColor = Color.FromHex("#8999A6"),//your color here
                //BarTextColor = Color.White
            };
        }
    }
}
