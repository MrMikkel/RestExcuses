using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestExcuses.Managers;
using RestExcuses.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestExcuses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcuseController : ControllerBase
    {

        private IExcusesManager _manager;

        public ExcuseController(ExcusesContext context)
        {
            _manager = new ExcuseManagerDB(context);
        }

        // GET: api/<ExcuseController>
        [HttpGet]
        public IEnumerable<Excuses> Get()
        {
            return _manager.GetAll();
        }

        // GET api/<ExcuseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ExcuseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ExcuseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExcuseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
