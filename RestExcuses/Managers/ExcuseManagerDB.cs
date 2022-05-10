using System;
using System.Collections;
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
        public IEnumerable<ExcuseClass> GetAll()
        {
            return _context.Excuses;
        }

        //get by id
        public ExcuseClass GetByID(int id)
        {
            return _context.Excuses.Find(id);
        }

        //tilføjer en excuse hvis den ikke er null
        public bool PostExcuse(ExcuseClass value)
        {
            value.Id = 0;
            if (value.Excuse != null)
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
        public ExcuseClass UpdateExcuse(/*int id,*/ ExcuseClass update)
        {
            //finder id'et som skal opdateres, med den id
            //anvender getbyid metoden til at optimere denne metode 
            //eller ændre hvordan man finder et specifikt excuse
            //ExcuseClass excuseToBeUpdated = GetByID(update.Id);
            //todo
            ExcuseClass excuseToBeUpdated = _context.Excuses.Find(update.Id);
            //todo

            excuseToBeUpdated.Excuse = update.Excuse;

            //gemme den opdaterede excuse i db, kalder vi savechanges
            _context.SaveChanges();
            //returner den opdaterede excuse
            return excuseToBeUpdated;
        }

        //overload method, med en string (så man ikke behøver at initialisere et obj.)
        public ExcuseClass UpdateExcuse(int id, string updateTheExcuse)
        {
            ExcuseClass excuseToBeUpdated = GetByID(id);

            excuseToBeUpdated.Excuse = updateTheExcuse;
            //gemme den opdaterede excuse i db, kalder vi savechanges
            _context.SaveChanges();
            //returner den opdaterede excuse
            return excuseToBeUpdated;
        }

        public bool DeleteExcuse(int tbd)
        {
            //ExcuseClass excuseToBeDeleted = GetByID(tbd.Id);
            ExcuseClass excuseToBeDeleted = _context.Excuses.Find(tbd);

            if (excuseToBeDeleted != null)
            {
                _context.Excuses.Remove(excuseToBeDeleted);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public ExcuseClass GetRandomExcuse()
        {
            Random rand = new Random();
            int count = _context.Excuses.Count();
            int randCount = rand.Next(0, count);
            IEnumerable<ExcuseClass> ExcuseList = _context.Excuses;
            ExcuseClass randExcuse = ExcuseList.ElementAt(randCount);
            return randExcuse;
        }
    }
}
