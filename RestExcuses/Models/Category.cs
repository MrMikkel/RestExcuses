using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestExcuses.Models
{
    public class Category
    {
        public string category { get; set; }
        private DateTime timeStamp { get; set; }

        public Category()
        {
        }

        public Category(string category)
        {
            this.category = category;
        }
    }
}
