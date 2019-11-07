using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIConfig.Models;
using APIConfig.Services;
using APIConfig.Services.Imp;
using APIDataBases.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIConfig.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class ConnectionStringController : Controller<ConnectionStrings>
    {
        public ConnectionStringController(IConnectionStringsService service) : base(service)
        {

        }
        [HttpGet("GetAllDatabases")]
        public IQueryable<GetAllDatabasesResult> GetAllDatabases()
        {
            return _service.GetAllDatabases();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("GetSchema")]
        public ConnectionStrings GetSchema([FromBody] SchemaCrawlerRequest request)
        {
            
            return ((IConnectionStringsService)_service).GetSchema(request.server, request.database, request.command, request.infoLevel, request.outputFile, request.outputFormat);
        }
    }
}