using APIConfig.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConfig.Services.Imp
{
    public interface IConnectionStringsService : IService<ConnectionStrings>
    {
        IList<GetTablesResult> GetAllTables(string DatabaseName);
        IList<GetFieldsResult> GetAllFields(string DatabaseName,string TableName);
        ConnectionStrings GetSchema(string server, string database, string command, string infoLevel, string outputFile, string outputFormat);
    }
}
