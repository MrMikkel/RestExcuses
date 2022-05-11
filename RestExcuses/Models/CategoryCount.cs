using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestExcuses.Models
{
    public class CategoryCount
    {
            public int Count { get; set; }
            public string Category { get; set; }

            public CategoryCount()
            {

            }

            public CategoryCount(int count, string category)
            {
                Count = count;
                Category = category;
            }
        }
    }



