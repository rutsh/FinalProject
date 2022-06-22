using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class FixedExpenseDAL : IFixedExpenseDAL
    {
        private readonly EconomyContext _context;
        public FixedExpenseDAL(EconomyContext context)
        {
            _context = context;
        }

        public async Task<List<FixedExpense>> GetByUserId(int id)
        {         
            List<FixedExpense> Fixedexpenses =await _context.FixedExpense.Where(e => e.FixedExUser == id).ToListAsync();
            return Fixedexpenses;

        }

        public async Task<List<FixedExpense>> GetByCategory(int categoryid, int userid)
        {
            List<FixedExpense> fExpense =await _context.FixedExpense.
                Where(x => x.FixedExCategory == categoryid && x.FixedExUser == userid).ToListAsync();
            return fExpense;
        }
        public async Task AddExpense(FixedExpense e)
        {
            //FixedExpense f = _context.FixedExpense.Where(p => p.FixedExCategory == e.FixedExCategory && p.FixedExUser == e.FixedExUser).OrderBy(p => p.FixedExTime).Reverse().FirstOrDefault();
            //e.FixedExPrev = f.FixedExId;
              _context.FixedExpense.Add(e);
             await _context.SaveChangesAsync();
        }

       
    }
}
