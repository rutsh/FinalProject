using DAL.Models;
using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IFixedIncomeBL
    {
        Task AddFixedIncome(FixedIncomeDTO ex);
        Task<List<FixedIncomeDTO>> GetByUserId(int id);
        Task putIncome(FixedIncomeDTO e, int prevId);
    }
}