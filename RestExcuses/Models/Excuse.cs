using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestExcuses.Models
{
    public class Excuse
    {
        public int Id { get; set; }
        public string ExcuseValue { get; set; }

        public Excuse()
        {

        }

        public Excuse(int id, string excuse)
        {
            Id = id;
            ExcuseValue = excuse;
        }
    }
}
