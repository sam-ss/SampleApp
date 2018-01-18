using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Models
{

   public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int EmpId { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }

        public int Age { get; set; }
    }
}
