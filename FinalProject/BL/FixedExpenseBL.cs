using AutoMapper;
using DAL;
using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FixedExpenseBL : IFixedExpenseBL
    {
        IMapper mapper;
        private readonly IFixedExpenseDAL _fixedExpenseDAL;

        public FixedExpenseBL(IFixedExpenseDAL fixedExpenseDAL)
        {
            _fixedExpenseDAL = fixedExpenseDAL;
          
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            mapper = config.CreateMapper();
        }

        public async Task<List<FixedExpenseDTO>> GetByUserId(int id)
        {
            List<FixedExpense> ex =await _fixedExpenseDAL.GetByUserId(id);
            return mapper.Map<List<FixedExpense>, List<FixedExpenseDTO>>(ex);
        }

        public async Task<List<FixedExpenseDTO>> GetByCategory(int cId, int uId)
        {
            List<FixedExpense> ex =await _fixedExpenseDAL.GetByCategory(cId, uId);

            if (ex == null)
                return null;
            return mapper.Map<List<FixedExpense>, List<FixedExpenseDTO>>(ex);
        }

        public async Task AddFixedExpense(FixedExpenseDTO ex)
        {
           
            FixedExpense fixedEx=mapper.Map<FixedExpenseDTO, FixedExpense>(ex);
            await _fixedExpenseDAL.AddExpense(fixedEx);
        }


    }
}
