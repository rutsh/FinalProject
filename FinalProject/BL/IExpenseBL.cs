using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IExpenseBL
    {
        Task AddExpense(ExpenseDTO ex);
        Task<List<ExpenseDTO>> GetByUserId(int id);
    }
}