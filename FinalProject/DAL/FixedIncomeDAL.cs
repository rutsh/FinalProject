using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
  public  class FixedIncomeDAL : IFixedIncomeDAL
    {

        private readonly EconomyContext _context;
        public FixedIncomeDAL(EconomyContext context)
        {
            _context = context;
        }

        public async Task<List<FixedIncome>> GetByUserId(int id)
        {
            List<FixedIncome> Fixedincomes =await _context.FixedIncome.Where(e => e.FixedInUser == id).ToListAsync();
            return Fixedincomes;

        }

        public async Task AddIncome(FixedIncome e)
        {
             _context.FixedIncome.Add(e);
            await _context.SaveChangesAsync();
        }

        public async Task putIncome(FixedIncome e, int prevId)
        {
            e.FixedInPrev = prevId;
            //FixedIncome f = _context.FixedExpense.Where(p => p.FixedExCategory == e.FixedExCategory && p.FixedExUser == e.FixedExUser).OrderBy(p => p.FixedExTime).Reverse().FirstOrDefault();
            //e.FixedExPrev = f.FixedExId;
            await this.AddIncome(e);
        }


    }
}
