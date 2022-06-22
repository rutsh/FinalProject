using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.Models
{
    public partial class Expense
    {
        public int ExpenseId { get; set; }
        public double ExpenseSum { get; set; }
        public int ExpenseUser { get; set; }
        public DateTime ExpenseTime { get; set; }
        public int ExpenseCategory { get; set; }

        public virtual Categories ExpenseCategoryNavigation { get; set; }
        public virtual Users ExpenseUserNavigation { get; set; }
    }
}
