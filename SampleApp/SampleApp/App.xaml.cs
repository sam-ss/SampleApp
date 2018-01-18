using SampleApp.Business.DataBase;
using SampleApp.Business.Interfaces;
using SampleApp.ViewModels;
using SampleApp.Views;
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

            //MainPage = new EmployeeListPage();
            MainPage = new NavigationPage(new EmployeeListPage());
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
