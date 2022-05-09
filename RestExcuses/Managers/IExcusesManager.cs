using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestExcuses.Models;

namespace RestExcuses.Managers
{
    interface IExcusesManager
    {
        //interface er nødvendig hvis man skal bruge Ienumerable
        IEnumerable<Excuse> GetAll();
    }
}
