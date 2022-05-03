using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestExcuses.Models
{
    public class ExcusesContext : DbContext
    {

        //database tilføjelse

        public ExcusesContext(DbContextOptions<ExcusesContext> options) : base(options){}

        public DbSet<Excuses> Excuses { get; set; }

        //tom constructer er nødvendig ellers virker det ikke
        public ExcusesContext()
        {

        }

    }
}
