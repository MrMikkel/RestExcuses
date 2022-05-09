using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestExcuses.Models;

namespace RestExcuses.Managers
{
    public class ExcuseManagerDB : IExcusesManager
    {
        // tom constructor
        public ExcuseManagerDB()
        {

        }

        // reference til dbcontext
        private ExcusesContext _context;
        //initialize dbcontext
        public ExcuseManagerDB(ExcusesContext context)
        {
            _context = context;
        }

        //get all excuses i databasen til en list
        public IEnumerable<Excuse> GetAll()
        {
            return _context.Excuses;
        }

        //tilføjer en excuse hvis den ikke er null
        public bool PostExcuse(Excuse value)
        {
            value.Id = 0;
            if (value.ExcuseValue!=null)
            {
                _context.Excuses.Add(value);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
