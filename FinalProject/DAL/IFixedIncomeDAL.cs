using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
  public  interface IFixedIncomeDAL
    {
        Task AddIncome(FixedIncome e);
        Task<List<FixedIncome>> GetByUserId(int id);
        Task putIncome(FixedIncome e, int prevId);
    }
}