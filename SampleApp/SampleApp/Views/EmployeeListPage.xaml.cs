using SampleApp.Models;
using SampleApp.Utils;
using SampleApp.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeListPage : ContentPage
    { 
        EmployeeViewModel _viewmodel;
        public EmployeeListPage()
        {
            BindingContext = App.Locator.EmployeeViewModel;
            _viewmodel = BindingContext as EmployeeViewModel;
            InitializeComponent();
            Title = PageConstants.EMPLOYEE_LIST_PAGE_TITLE;
            var toolbarItem = new ToolbarItem
            {
                //Text = "+"
                Icon = Constants.PLUS_IMAGE
            };
            toolbarItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new EmployeePage() { BindingContext = new Employee() });
            };
            ToolbarItems.Add(toolbarItem);
            EmployeeListView.SetBinding(ListView.ItemsSourceProperty, PropertyConstants.EMPLOYEE_LIST);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            _viewmodel.RefreshCommand.Execute(null);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _viewmodel.Cleanup();
        }
        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new EmployeePage() { BindingContext = e.SelectedItem as Employee });
            }
        }
    }
}
