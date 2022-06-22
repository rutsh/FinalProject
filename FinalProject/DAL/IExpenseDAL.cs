using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface IExpenseDAL
    {
        Task AddExpense(Expense e);
        Task<List<Expense>> GetByUserId(int id);
    }
}