using SampleApp.Models;
using SampleApp.Utils;
using SampleApp.ViewModels;
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
    public partial class EmployeePage : ContentPage
    {
        EmployeeViewModel _viewmodel;
        public EmployeePage()
        {
            BindingContext = App.Locator.EmployeeViewModel;
            _viewmodel = BindingContext as EmployeeViewModel;
            InitializeComponent();
            Title = PageConstants.ADD_EMPLOYEE_PAGE_TITLE;
        }
        async void Save_Clicked(object sender, System.EventArgs e)
        {
            var personItem = (Employee)BindingContext;
            _viewmodel.SaveEmployeeCommand.Execute(personItem); 
            await Navigation.PopAsync();
        }
        async void Cancel_Clicked(object sender, System.EventArgs e)
        {
            var personItem = (Employee)BindingContext;
            _viewmodel.DeleteEmployeeCommand.Execute(personItem);
            await Navigation.PopAsync();
        }
    }
}