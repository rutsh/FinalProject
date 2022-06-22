using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.Models
{
    public partial class Income
    {
        public int IncomeId { get; set; }
        public double IncomeSum { get; set; }
        public int IncomeUser { get; set; }
        public DateTime IncomeTime { get; set; }

        public virtual Users IncomeUserNavigation { get; set; }
    }
}
