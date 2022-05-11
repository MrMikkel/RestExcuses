using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RestExcuses.Managers;
using RestExcuses.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestExcuses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcusesController : ControllerBase
    {
        //initialize manager classen
        private IExcusesManager _manager;
        //innitialize dbcontext
        public ExcusesController(ExcusesContext context)
        {
            _manager = new ExcusesManagerDB(context);
        }

        // GET: api/<ExcuseController>
        // get metode der gør brug af GetAll fra manager klassen
        [HttpGet]
        public IEnumerable<ExcuseClass> Get()
        {
            return _manager.GetAll();
        }

        // GET api/<ExcuseController>/5
        [HttpGet("{id}")]
        //hente en specifik excuse fra manager listen, 
        //retuner null hvis obj. ikke er fundet  
        public ActionResult<ExcuseClass> Get(int id)
        {
            ExcuseClass result = _manager.GetByID(id);
            if (result == null)
                return NotFound("No such excuse with id: " + id);
            return Ok(result);
        }
        // GET api/<ExcuseController>/5
        [HttpGet("/api/Excuse/random")]
        public ExcuseClass GetRandom()
        {
            return  _manager.GetRandomExcuse();
            
        }

        // POST api/<ExcuseController>
        [HttpPost]
        public ExcuseClass Post([FromBody] ExcuseClass value)
        {
            return _manager.PostExcuse(value);
        }


        // PUT api/<ExcuseController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //todo look below
        [HttpPut/*("{id}")*/]
        //sender id og excuse obj. til manager for at opdater vædierne 
        //id i obj. bliver ignoredet, retuner null hvis ingen excuse har den id
        //{id} annotation denne gør at URL til obj. forventer en int 
        // FromBody i parameter denne forventer Json body fra requesten 
        public ActionResult<ExcuseClass> Put(/*int id,*/ [FromBody] ExcuseClass updateExcuseClass)
        {
            ExcuseClass result = _manager.UpdateExcuse(/*id,*/ updateExcuseClass);
            if (result == null) 
                return NotFound("No such excuse with id: " + updateExcuseClass.Id);
            return Ok(result);
        }
        //todo above

        // DELETE api/<ExcuseController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _manager.DeleteExcuse(id);
        }
    }
}
