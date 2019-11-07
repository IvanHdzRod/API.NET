using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIConfig.Models;
using APIConfig.Services;
using APIConfig.Services.Imp;
using Microsoft.AspNetCore.Mvc;

namespace APIConfig.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDatabasesController : Controller<ConnectionStrings>
    {
        public GetDatabasesController(IConnectionStringsService service) : base(service)
        {
            
        }
        [HttpGet("GetDatabases")]
        public IList<GetTablesResult> GetAllDatabases(string DatabaseName)
        {
            return ((IConnectionStringsService)_service).GetAllTables(DatabaseName);
        }

        [HttpGet("GetTables")]
        public IList<GetFieldsResult> GetAllFields(string DatabaseName, string TableName)
        {
            return ((IConnectionStringsService)_service).GetAllFields(DatabaseName,TableName);
        }
    }
}