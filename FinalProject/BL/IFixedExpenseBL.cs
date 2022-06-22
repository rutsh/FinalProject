using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IFixedExpenseBL
    {
        Task AddFixedExpense(FixedExpenseDTO ex);
        Task<List<FixedExpenseDTO>> GetByCategory(int cId, int uId);
       Task<List<FixedExpenseDTO>> GetByUserId(int id);
    }
}