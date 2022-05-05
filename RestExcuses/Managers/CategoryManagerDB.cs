using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestExcuses.Models;

namespace RestExcuses.Managers
{
    public class CategoryManagerDB
    {
        public CategoryManagerDB()
        {

        }

        //initialize dbcontext
        private ExcusesContext _context;
        //initialize dbcontext
        public CategoryManagerDB(ExcusesContext context)
        {
            _context = context;
        }


    }
}
