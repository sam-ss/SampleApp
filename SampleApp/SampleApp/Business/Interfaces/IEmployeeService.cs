using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Business.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> DeleteEmployeeAsync(Employee item);
        Task<Employee> GetEmployeeAsync(int id);
        Task<List<Employee>> GetEmployeesAsync();
        Task<int> SaveEmployeeAsync(Employee item);
    }
}
