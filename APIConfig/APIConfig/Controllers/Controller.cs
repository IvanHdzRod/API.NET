using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIConfig.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIConfig.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller<T>: ControllerBase where T :class
    {
        protected readonly IService<T> _service;
        public Controller(IService<T> service)
        {
            this._service = service;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<T>> Get()
        {
            return Ok(_service.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_service.GetAsync(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] T value)
        {
            _service.AddAsync(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] T value)
        {
            return Ok(_service.UpdateAsync(id, value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(_service.DeleteAsync(id));
        }
    }
}