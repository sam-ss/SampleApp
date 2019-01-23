using Acr.UserDialogs;
using GalaSoft.MvvmLight.Ioc;
using SampleApp.Business.DataBase;
using SampleApp.Business.Interfaces;
using SampleApp.ViewModels;
using SampleApp.Views;
using SampleApp.Views.MapPages;
using SampleApp.Views.XamlControls;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SampleApp
{
    public partial class App : Application
    {
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator => _locator ?? new ViewModelLocator();
        static DatabaseService database;

        public App()
        {
            InitializeComponent();

            // MainPage = new XamlControlPage();
            //MainPage = new NavigationPage(new EmployeeListPage());

            //SimpleIoc.Default.Register(() => UserDialogs.Instance);
            //App.Current.MainPage = new NavigationPage(new Views.LoginPage());

            try
            {
                var tabs = new TabbedPage();

                // demonstrates the map control with zooming and map-types
                tabs.Children.Add(new MapPage { Title = "Map/Zoom", Icon = "glyphish_74_location.png" });

                // demonstrates the map control with zooming and map-types
                tabs.Children.Add(new PinPage { Title = "Pins", Icon = "glyphish_07_map_marker.png" });

                // demonstrates the Geocoder class
                tabs.Children.Add(new GeocoderPage { Title = "Geocode", Icon = "glyphish_13_target.png" });

                // opens the platform's native Map app
                tabs.Children.Add(new MapAppPage { Title = "Map App", Icon = "glyphish_103_map.png" });

                MainPage = tabs;
            }
            catch (Exception ex)
            {

                 
            }
        }

        public static DatabaseService Database
        {
            get
            {
                if (database == null)
                {
                    database = new DatabaseService(DependencyService.Get<ILocalFileHelper>().GetAsyncConnection());
                }

                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
