using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class FixedExpenseDTO
    {
        public int FixedExId { get; set; }
        public double FixedExSum { get; set; }
        public int FixedExUser { get; set; }
        public DateTime FixedExTime { get; set; }
        public int? FixedExPrev { get; set; }
        public int FixedExCategory { get; set; }
    }
}
