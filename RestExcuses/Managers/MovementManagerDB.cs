using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestExcuses.Models;

namespace RestExcuses.Managers
{
    public class MovementManagerDB
    {
        public MovementManagerDB()
        {

        }

        //initialize dbcontext
        private ExcusesContext _context;
        //initialize dbcontext
        public MovementManagerDB(ExcusesContext context)
        {
            _context = context;
        }

        public void postMovement(Movement move)
        {
            Movement movement = new Movement(move.movement, DateTime.Now);
            _context.Movement.Add(movement);
            _context.SaveChanges();
        }

        public Movement GetLastEntry()
        {
            return _context.Movement.Last();
        }

    }
}
