using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoriesDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool? CategoryFixed { get; set; }
    }
}
