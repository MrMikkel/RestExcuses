using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestExcuses.Models
{
    public class Excuses
    {
        public int Id { get; set; }
        public string Excuse { get; set; }

        public Excuses()
        {

        }

        public Excuses(int id, string excuse)
        {
            Id = id;
            Excuse = excuse;
        }
    }
}
