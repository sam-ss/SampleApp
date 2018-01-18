using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Business.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// delete Employee form database
        /// </summary>
        /// <param name="item"> Existing exployee object</param>
        /// <returns></returns>
        Task<int> DeleteEmployeeAsync(Employee item);
        /// <summary>
        /// Get single employee by ID
        /// </summary>
        /// <param name="id">Employee Id </param>
        /// <returns> Employee Object</returns>
        Task<Employee> GetEmployeeAsync(int id);
        /// <summary>
        /// Get List of all Employee from database
        /// </summary>
        /// <returns>Return List Of Employee</returns>
        Task<List<Employee>> GetEmployeesAsync();
        /// <summary>
        /// Save Employee to database
        /// </summary>
        /// <param name="item">Employee object</param>
        /// <returns></returns>
        Task<int> SaveEmployeeAsync(Employee item);
    }
}
