using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Expense = new HashSet<Expense>();
            FixedExpense = new HashSet<FixedExpense>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool? CategoryFixed { get; set; }

        public virtual ICollection<Expense> Expense { get; set; }
        public virtual ICollection<FixedExpense> FixedExpense { get; set; }
    }
}
