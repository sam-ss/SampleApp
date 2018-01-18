using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using SampleApp.Business.Interfaces;
using SampleApp.Business.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<IEmployeeService, EmployeeService>(); 

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            SimpleIoc.Default.Register<EmployeeViewModel>();
        }

        public EmployeeViewModel EmployeeViewModel
        {
            get
            {
                if (!SimpleIoc.Default.IsRegistered<EmployeeViewModel>())
                {
                    SimpleIoc.Default.Register<EmployeeViewModel>();
                }
                return ServiceLocator.Current.GetInstance<EmployeeViewModel>();
            }
        }
    }
}
