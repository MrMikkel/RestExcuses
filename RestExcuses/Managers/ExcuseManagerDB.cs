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
        private ExcusesContext _context;

        public ExcuseManagerDB(ExcusesContext context)
        {
            _context = context;
        }

        public IEnumerable<Excuses> GetAll()
        {
            return _context.Excuses;
        }
    }
}
