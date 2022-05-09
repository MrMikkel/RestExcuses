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
            Movement item = _context.Movement.OrderBy(x => x.timeStamp).Last();
            if ((DateTime.UtcNow - item.timeStamp).TotalSeconds < 60)
            {
                return item;
            }
            else
            {
                return null;
            }
        }

    }
}
