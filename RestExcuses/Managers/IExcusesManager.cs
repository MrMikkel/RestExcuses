using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestExcuses.Models;

namespace RestExcuses.Managers
{
    interface IExcusesManager
    {
        IEnumerable<Excuses> GetAll();
    }
}
