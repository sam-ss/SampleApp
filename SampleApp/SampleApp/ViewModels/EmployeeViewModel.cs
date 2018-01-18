using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SampleApp.Business.Interfaces;
using SampleApp.Models;
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
        private RelayCommand _deleteEmployeeCommand;

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

        public RelayCommand<Employee> SaveEmployeeCommand
        {
            get
            {
                return _saveEmployeeCommand ??
                    (_saveEmployeeCommand = new RelayCommand<Employee>(async (emp) =>
                    {
                        try
                        {
                            var test = await _employeeService.SaveEmployeeAsync(emp);

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

        public RelayCommand DeleteEmployeeCommand
        {
            get
            {
                return _deleteEmployeeCommand ??
                    (_deleteEmployeeCommand = new RelayCommand(async () =>
                    {
                        try
                        {
                            Employee employee = new Employee(); 
                            var test = _employeeService.DeleteEmployeeAsync(employee); 
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
