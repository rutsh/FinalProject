using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IIncomeBL
    {
        Task AddIncome(IncomeDTO ex);
        Task<List<IncomeDTO>> GetByUserId(int id);
    }
}