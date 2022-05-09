using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestExcuses.Models;

namespace RestExcuses.Managers
{
    public class MovementManagerDB
    {
        // tom constructor
        public MovementManagerDB()
        {

        }

        // reference til dbcontext
        private ExcusesContext _context;
        // initialize dbcontext
        public MovementManagerDB(ExcusesContext context) // dependency injection
        {
            _context = context;
        }

        // Post en bevægelse + timestamp fra proxy/ manuelt
        public void PostMovement(Movement move)
        {
            _context.Movement.Add(move);
            _context.SaveChanges();
        }

        // henter den sidste entry i databasen
        public Movement GetLastEntry()
        {
            Movement item = _context.Movement.OrderBy(x => x.timeStamp).Last(); // det nyeste objekt fra databasen hentes
            if ((DateTime.UtcNow - item.timeStamp).TotalSeconds < 60) // hvis nyeste objekt er over 60 sekunder gammelt, ignoreres det
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
