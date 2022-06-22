using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ExpenseDTO
    {
        public int ExpenseId { get; set; }
        public double ExpenseSum { get; set; }
        public int ExpenseUser { get; set; }
        public DateTime ExpenseTime { get; set; }
        public int ExpenseCategory { get; set; }
    }
}
