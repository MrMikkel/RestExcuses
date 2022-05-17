using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using RestExcuses.Models;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace RestExcuses.Managers
{
    public class MovementsManagerDB
    {
        // tom constructor
        public MovementsManagerDB()
        {

        }

        // reference til dbcontext
        private ExcusesContext _context;
        // initialize dbcontext
        public MovementsManagerDB(ExcusesContext context) // dependency injection
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
            try
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
            catch (InvalidOperationException e)
            {
                return null;
            }
            
        }

        public int DeleteAllMovements()
        {
            // Linq virked ikke vi bruget sql commando for at slette alt 
            string deleteCommand = "DELETE FROM Movement";
            SqlConnection connection = new SqlConnection(Secret.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(deleteCommand, connection);
            int tal = command.ExecuteNonQuery();
            connection.Close();
            return tal;

            //_context.Movement.Where(x => 1 == 1).DeleteFromQuery();

            //dette burde virke men gør ikke
            //_context.Movement.RemoveRange(_context.Movement);
            //_context.SaveChanges();
        }

        public IOrderedEnumerable<CategoryCount> GetHistory() // tæller bevægelser op og returnerer en sorteret liste med dem alle sammen i
        {
            // optælling
            int useCountRight = _context.Movement.Count(x => x.movement == "right");
            int useCountLeft = _context.Movement.Count(x => x.movement == "left");
            int useCountFront = _context.Movement.Count(x => x.movement == "front");
            int useCountBack = _context.Movement.Count(x => x.movement == "back");
            int useCountShake = _context.Movement.Count(x => x.movement == "shake");

            // liste
            List<CategoryCount> categoryList = new List<CategoryCount>();
            // tilføjelse til liste
            categoryList.Add(new CategoryCount(useCountRight,"Family"));
            categoryList.Add(new CategoryCount(useCountLeft, "Work"));
            categoryList.Add(new CategoryCount(useCountFront, "College"));
            categoryList.Add(new CategoryCount(useCountBack, "Party"));
            categoryList.Add(new CategoryCount(useCountShake, "My excuses"));

            // sortering af liste
            IOrderedEnumerable<CategoryCount> final = categoryList.OrderByDescending(c => c.Count);

            return final;
        }


    }
}
