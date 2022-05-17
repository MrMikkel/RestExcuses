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
    public class MovementsController : ControllerBase
    {
        // reference til managerklassen 
        private MovementsManagerDB _manager;
        // initialize dbcontext
        public MovementsController(ExcusesContext context) // dependency injection af dbcontext
        {
            _manager = new MovementsManagerDB(context); // manager-klassen initaliseres med db
        }

        // GET: api/<MovementController>
        [HttpGet]
        public Movement Get()
        {
            return _manager.GetLastEntry(); // returnerer et enkelt (det seneste) Movement-objekt
        }

        //GET api/<MovementController>/5
        [HttpGet("/api/Movements/topcategories")]
        public IOrderedEnumerable<CategoryCount> GetTopCategories()
        {
            return _manager.GetHistory();
        }

        // POST api/<MovementController>
        // opretter Movement
        [HttpPost]
        public void Post([FromBody] Movement value)
        {
            _manager.PostMovement(value);
        }

        // PUT api/<MovementController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //DELETE api/<MovementController>/5
        [HttpDelete]
        public int Delete()
        {
           return _manager.DeleteAllMovements();
        }
    }
}
