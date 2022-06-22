using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
     public class IncomeDTO
    {
        public int IncomeId { get; set; }
        public double IncomeSum { get; set; }
        public int IncomeUser { get; set; }
        public DateTime IncomeTime { get; set; }
    }
}
