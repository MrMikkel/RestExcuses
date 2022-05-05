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
    public class MovementController : ControllerBase
    {

        private MovementManagerDB _manager;
        //innitialize dbcontext
        public MovementController(ExcusesContext context)
        {
            _manager = new MovementManagerDB(context);
        }

        // GET: api/<MovementController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MovementController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<MovementController>
        [HttpPost]
        public void Post([FromBody] Movement value)
        {
            _manager.postMovement(value);
        }

        // PUT api/<MovementController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<MovementController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
