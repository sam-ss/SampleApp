using SampleApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Business.DataBase
{
    public class DatabaseService
    {

        public static SQLiteAsyncConnection database;
        public  DatabaseService(String dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<Employee>().Wait(); 

            Debug.WriteLine("Database Path: "+ dbPath);
        }
        public SQLiteAsyncConnection DataService(/*String dbPath*/)
        {
            //database = new SQLiteAsyncConnection(dbPath); 
            return database;
        }
        

    }
}
