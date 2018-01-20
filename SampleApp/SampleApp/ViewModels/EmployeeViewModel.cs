using Acr.UserDialogs;
using FluentValidation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SampleApp.Business.Interfaces;
using SampleApp.Models;
using SampleApp.Validator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SampleApp.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {
        private IEmployeeService _employeeService;
        private RelayCommand _refreshCommand;
        private ObservableCollection<Employee> _employeeList;
        private RelayCommand<Employee> _saveEmployeeCommand;
        private RelayCommand<Employee> _deleteEmployeeCommand;
        private readonly IValidator _validator;

        #region Property
        public ObservableCollection<Employee> EmployeeList
        {
            get { return _employeeList; }

            set
            {
                Set(() => EmployeeList, ref _employeeList, value);
            }
        }
        #endregion

        public EmployeeViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _validator = new AddemployeeValidator();
        }

        #region RelayCommands
        public RelayCommand RefreshCommand
        {
            get
            {
                return _refreshCommand ??
                    (_refreshCommand = new RelayCommand(async () =>
                    {
                        try
                        {
                            var test = await _employeeService.GetEmployeesAsync();
                            EmployeeList = new ObservableCollection<Employee>(test);
                        }
                        catch (Exception ex)
                        {

                        }
                        finally
                        {
                        }

                    }));
            }
        }

        /// <summary>
        /// command use To Save Employee in Database 
        /// Need Employee object
        /// </summary>
        public RelayCommand<Employee> SaveEmployeeCommand
        {
            get
            {
                return _saveEmployeeCommand ??
                    (_saveEmployeeCommand = new RelayCommand<Employee>(async (emp) =>
                    {
                        try
                        {
                            var validationResult = _validator.Validate(emp);
                            if (validationResult.IsValid)
                            {
                                var test = await _employeeService.SaveEmployeeAsync(emp);
                            }
                            else
                            {
                                AlertConfig alert = new AlertConfig
                                {
                                    Message = validationResult.Errors[0].ErrorMessage,
                                    OkText = "Ok"
                                };
                                UserDialogs.Instance.Alert(alert);
                                //Acr.UserDialogs.UserDialogs.Instance.ShowLoading(validationResult.Errors[0].ErrorMessage);
                                // UserDialogs.Instance.ShowError(validationResult.Errors[0].ErrorMessage, 3000);
                            }
                            

                        }
                        catch (Exception ex)
                        {

                        }
                        finally
                        {
                        }

                    }));
            }
        }

        public RelayCommand<Employee> DeleteEmployeeCommand
        {
            get
            {
                return _deleteEmployeeCommand ??
                    (_deleteEmployeeCommand = new RelayCommand<Employee>(async (emp) =>
                    {
                        try
                        { 
                            var test = await _employeeService.DeleteEmployeeAsync(emp);
                            
                        }
                        catch (Exception ex)
                        {

                        }
                        finally
                        {
                        }

                    }));
            }
        }

        #endregion

        public override void Cleanup()
        {
            base.Cleanup();
            _employeeList = null;
        }
    }
}
