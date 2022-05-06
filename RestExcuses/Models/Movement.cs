using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestExcuses.Models
{
    public class Movement
    {
        [Key, Column(Order = 0)]
        public DateTime timeStamp { get; set; }
        [Key, Column(Order = 1)]
        public string movement { get; set; }


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
