using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.Models
{
    public partial class FixedIncome
    {
        public FixedIncome()
        {
            InverseFixedInPrevNavigation = new HashSet<FixedIncome>();
        }

        public int FixedInId { get; set; }
        public double FixedInSum { get; set; }
        public int FixedInUser { get; set; }
        public DateTime FixedInTime { get; set; }
        public int? FixedInPrev { get; set; }

        public virtual FixedIncome FixedInPrevNavigation { get; set; }
        public virtual Users FixedInUserNavigation { get; set; }
        public virtual ICollection<FixedIncome> InverseFixedInPrevNavigation { get; set; }
    }
}
