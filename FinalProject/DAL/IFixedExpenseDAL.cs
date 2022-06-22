using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface IFixedExpenseDAL
    {
        Task AddExpense(FixedExpense e);
        Task<List<FixedExpense>> GetByCategory(int categoryid, int userid);
        Task<List<FixedExpense>> GetByUserId(int id );
    }
}