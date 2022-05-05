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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movement>().HasKey(p => new { p.movement, p.timeStamp });
        }

        public DbSet<Excuses> Excuses { get; set; }
        public DbSet<Movement> Movement { get; set; }

        //tom constructer er nødvendig ellers virker det ikke
        public ExcusesContext()
        {

        }

    }
}
