using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestExcuses.Models
{
    public class Movement
    {
        public string movement { get; set; }
        private DateTime timeStamp { get; set; }

        public Movement()
        {
        }

        public Movement(string movement, DateTime timestamp)
        {
            this.movement = movement;
            timeStamp = timestamp;
        }
    }
}
