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
    public class IncomeBL : IIncomeBL
    {
        IMapper mapper;
        private readonly IIncomeDAL _incomeDL;

        public IncomeBL(IIncomeDAL incomeDL)
        {
            _incomeDL = incomeDL;
       
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            mapper = config.CreateMapper();
        }

        public async Task<List<IncomeDTO>> GetByUserId(int id)
        {
            List<Income> ex =await _incomeDL.GetByUserId(id);
            return mapper.Map<List<Income>, List<IncomeDTO>>(ex);
        }

        

        public async Task AddIncome(IncomeDTO ex)
        {
          
           await _incomeDL.AddIncome(mapper.Map<IncomeDTO, Income>(ex));
        }

    }
}
