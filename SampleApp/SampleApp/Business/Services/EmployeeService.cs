using SampleApp.Business.DataBase;
using SampleApp.Business.Interfaces;
using SampleApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleApp.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private SQLiteAsyncConnection database;
        public EmployeeService()
        {
            //   database = App.DbConneciton;
            database = App.Database.DataService();
        }

        public Task<List<Employee>> GetEmployeesAsync()
        {
            return database.Table<Employee>().ToListAsync();
        }


        public Task<Employee> GetEmployeeAsync(int id)
        {
            return database.Table<Employee>().Where(i => i.EmpId == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveEmployeeAsync(Employee item)
        {
            if (item.EmpId != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteEmployeeAsync(Employee item)
        {
            return database.DeleteAsync(item);
        }
    }
}
