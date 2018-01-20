using SampleApp.Models;
using SampleApp.Views.XamlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuListPage : ContentPage
	{
        public Action<ContentPage> OnMenuSelect
        {
            get;
            set;
        }

        public MenuListPage ()
        {
            InitializeComponent();
            img.Source = "icon.png";
            var categories = new List<Category>()
            {
                new Category("Menu Page1", () => new EmployeeListPage(),"icon.png"),
                new Category("Menu Page2", () => new ComingSoonPage(),"icon.png"),
                new Category("Menu Page3", () => new XamlControlPage(),"icon.png"),
                new Category("Logout", () => new LoginPage(),"ic_sign_out.png")
            };

            listed.BackgroundColor = Color.White;

         //   string howILook = UserInformation.Image;

            //img.Source = new UriImageSource
            //{
            //    Uri = new Uri(howILook),
            //    CachingEnabled = true,
            //    CacheValidity = new TimeSpan(1, 0, 0, 0) //Caching image for a day
            //};

            myName.Text = "Welcome Mr. " + UserInformation.Username;

            listed.ItemsSource = categories;


            listed.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                if (OnMenuSelect != null)
                {
                    var category = (Category)e.SelectedItem;
                    if (category.Name == "Logout")
                    {
                        App.Current.MainPage = new NavigationPage(new Views.LoginPage())
                        {
                            //BarBackgroundColor = Color.FromHex("#8999A6"),
                            //BarTextColor = Color.White
                        };
                    }
                    else
                    {
                        var categoryPage = category.PageFn();
                        OnMenuSelect(categoryPage);
                    }

                }
            };
        }
    }
}
