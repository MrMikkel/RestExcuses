using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestExcuses.Models
{
    public class ExcuseClass
    {
        public int Id { get; set; }
        public string Excuse { get; set; }

        public ExcuseClass()
        {

        }

        public ExcuseClass(int id, string excuse)
        {
            Id = id;
            Excuse = excuse;
        }
    }
}
