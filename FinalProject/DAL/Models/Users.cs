using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.Models
{
    public partial class Users
    {
        public Users()
        {
            Expense = new HashSet<Expense>();
            FixedExpense = new HashSet<FixedExpense>();
            FixedIncome = new HashSet<FixedIncome>();
            Income = new HashSet<Income>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public string UserPassword { get; set; }
        public int? UserFamilySize { get; set; }

        public virtual ICollection<Expense> Expense { get; set; }
        public virtual ICollection<FixedExpense> FixedExpense { get; set; }
        public virtual ICollection<FixedIncome> FixedIncome { get; set; }
        public virtual ICollection<Income> Income { get; set; }
    }
}
