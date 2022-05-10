using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestExcuses.Models;

namespace RestExcuses.Managers
{
    interface IExcusesManager
    {
        // interface er nødvendig hvis man skal bruge Ienumerable
        // databasen returnerer IEnumerable, derfor skal vi tage i mod IEnumerable
        IEnumerable<ExcuseClass> GetAll();
        public ExcuseClass GetByID(int id);
        public bool PostExcuse(ExcuseClass value);
        public ExcuseClass UpdateExcuse(/*int id,*/ ExcuseClass update);
        public bool DeleteExcuse(int tbd);
        public ExcuseClass GetRandomExcuse();
    }
}
