using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestExcuses.Models
{
    public class ExcusesContext : DbContext
    {
        public ExcusesContext(DbContextOptions<ExcusesContext> options) : base(options){}

        public DbSet<Excuses> Excuses { get; set; }

        public ExcusesContext()
        {

        }

    }
}
