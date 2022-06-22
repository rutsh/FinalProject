using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DAL.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class IncomeDAL : IIncomeDAL
    {
        private readonly EconomyContext _context;
        public IncomeDAL(EconomyContext context)
        {
            _context = context;
        }

        public async Task<List<Income>> GetByUserId(int id)
        {
            List<Income> incomes =await _context.Income.Where(e => e.IncomeUser == id).ToListAsync();
            return incomes;

        }

       
        public async Task AddIncome(Income income)
        {
            _context.Income.Add(income);
           await _context.SaveChangesAsync();
        }

     
    }
}
