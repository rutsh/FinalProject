using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public interface IIncomeDAL
    {
        Task AddIncome(Income income);
        Task<List<Income>> GetByUserId(int id);
    }
}