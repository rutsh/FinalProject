using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.Models
{
    public partial class FixedExpense
    {
        public FixedExpense()
        {
            InverseFixedExPrevNavigation = new HashSet<FixedExpense>();
        }

        public int FixedExId { get; set; }
        public double FixedExSum { get; set; }
        public int FixedExUser { get; set; }
        public DateTime FixedExTime { get; set; }
        public int? FixedExPrev { get; set; }
        public int FixedExCategory { get; set; }

        public virtual Categories FixedExCategoryNavigation { get; set; }
        public virtual FixedExpense FixedExPrevNavigation { get; set; }
        public virtual Users FixedExUserNavigation { get; set; }
        public virtual ICollection<FixedExpense> InverseFixedExPrevNavigation { get; set; }
    }
}
