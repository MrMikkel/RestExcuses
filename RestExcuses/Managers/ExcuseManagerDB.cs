using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestExcuses.Models;

namespace RestExcuses.Managers
{
    public class ExcuseManagerDB : IExcusesManager
    {
        public ExcuseManagerDB()
        {

        }

        //initialize dbcontext
        private ExcusesContext _context;
        //initialize dbcontext
        public ExcuseManagerDB(ExcusesContext context)
        {
            _context = context;
        }

        //get all excuses i databasen til en list
        public IEnumerable<Excuses> GetAll()
        {
            return _context.Excuses;
        }
    }
}
