using SampleApp.Utils;
using SQLite;
using System;

namespace SampleApp.Business.Interfaces
{
    public interface ILocalFileHelper
    {
        string GetAsyncConnection(string filename = Constants.DATABASE_NAME_SQLITE); 
    }
}
