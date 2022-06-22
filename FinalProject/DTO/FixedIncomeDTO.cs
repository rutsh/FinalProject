using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
  public  class FixedIncomeDTO
    {

        public int FixedInId { get; set; }
        public double FixedInSum { get; set; }
        public int FixedInUser { get; set; }
        public DateTime FixedInTime { get; set; }
        public int? FixedInPrev { get; set; }

    }
}
