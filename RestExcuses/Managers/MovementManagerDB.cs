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

        public void PostMovement(Movement move)
        {
            _context.Movement.Add(move);
            _context.SaveChanges();
        }

        public Movement GetLastEntry()
        {
            IEnumerable<Movement> list = _context.Movement;
            return list.Last();
        }

    }
}
