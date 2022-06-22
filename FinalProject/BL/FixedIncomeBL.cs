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
    public class FixedIncomeBL : IFixedIncomeBL
    {
        IMapper mapper;
        private readonly IFixedIncomeDAL _FixedIncomeDAL;

        public FixedIncomeBL(IFixedIncomeDAL FixedIncomeDAL)
        {
            _FixedIncomeDAL = FixedIncomeDAL;
            // config זה מופע של המחלקה AutoMapperProfile שנמצא ב-DTO 
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            mapper = config.CreateMapper();
        }

        public async Task<List<FixedIncomeDTO>> GetByUserId(int id)
        {
            List<FixedIncome> ex =await _FixedIncomeDAL.GetByUserId(id);
            return mapper.Map<List<FixedIncome>, List<FixedIncomeDTO>>(ex);
        }

        public async Task AddFixedIncome(FixedIncomeDTO ex)
        {
           await _FixedIncomeDAL.AddIncome(mapper.Map<FixedIncomeDTO, FixedIncome>(ex));
        }

        public async Task putIncome(FixedIncomeDTO e, int prevId)
        {
           await _FixedIncomeDAL.putIncome(mapper.Map<FixedIncomeDTO, FixedIncome>(e),prevId);
        }


    }
}
