using APIConfig.Models;
using APIConfig.Repository;
using APIConfig.Services.Imp;
using APIConfig.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace APIConfig.Services
{
    public class ConnectionStringService : Service<ConnectionStrings>, IConnectionStringsService
    {
        public ConnectionStringService(IRepository<ConnectionStrings> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public IList<GetFieldsResult> GetAllFields(string DatabaseName,string TableName)
        {
            IList<GetFieldsResult> getFieldsResults = new List<GetFieldsResult>();
            var db = _repository.GetAll().Where(cs => cs.DatabaseName == DatabaseName).FirstOrDefault();

            using (SqlConnection subConn = new SqlConnection(db.Db))
            {
                SqlCommand subCmd = new SqlCommand("SELECT col.TABLE_CATALOG,col.TABLE_NAME,col.COLUMN_NAME,col.IS_NULLABLE,col.DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS col WHERE col.TABLE_NAME ='"+TableName+"'",subConn);
                subConn.Open();
                SqlDataReader subReader = subCmd.ExecuteReader();

                while(subReader.Read())
                {
                    getFieldsResults.Add(new GetFieldsResult
                    {
                        table_catalog = subReader["TABLE_CATALOG"].ToString(),
                        table_name = subReader["TABLE_NAME"].ToString(),
                        column_name= subReader["COLUMN_NAME"].ToString(),
                        is_nullable= subReader["IS_NULLABLE"].ToString(),
                        data_type = subReader["DATA_TYPE"].ToString()
                    });
                }
                return getFieldsResults;
            }
        }

        public IList<GetTablesResult> GetAllTables(string DatabaseName)
        {
            IList<GetTablesResult> getTablesResults = new List<GetTablesResult>();
            var db = _repository.GetAll().Where(cs => cs.DatabaseName == DatabaseName).FirstOrDefault();

            using (SqlConnection subConn = new SqlConnection(db.Db))
            {
                SqlCommand subCmd = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES", subConn);
                subConn.Open();
                SqlDataReader subReader = subCmd.ExecuteReader();

                while (subReader.Read())
                {
                    getTablesResults.Add(new GetTablesResult
                    {
                        table_catalog = subReader["TABLE_CATALOG"].ToString(),
                        table_name = subReader["TABLE_NAME"].ToString(),
                        table_schema = subReader["TABLE_SCHEMA"].ToString(),
                        table_type = subReader["TABLE_TYPE"].ToString()
                    }) ;
                }
                return getTablesResults;
            }
        }

        public ConnectionStrings GetSchema(string server, string database, string command, string infoLevel, string outputFile, string outputFormat)
        {
            Process cmd = new Process();
            cmd.StartInfo.WorkingDirectory = "C:/Users/e-ihernandezr/Desktop/_schemacrawler/schemacrawler-16.1.2-distribution/_schemacrawler";
            cmd.StartInfo.FileName = @"C:/Users/e-ihernandezr/Desktop/_schemacrawler/schemacrawler-16.1.2-distribution/_schemacrawler/schemacrawler.cmd";
            cmd.StartInfo.Arguments = "--server=" + server + " --database=" + database + " --command=" + command + " --info-level=" + infoLevel + " --output-file=C:/Schema/Files/" + outputFile + " --output-format=" + outputFormat;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine("echo Se corrio TODO");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
            throw new NotImplementedException();
        }
    }
}
