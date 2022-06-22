using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DTO;
using DAL.Models;
using System.Threading.Tasks;

namespace BL
{
    public class ExpenseBL : IExpenseBL
    {
        IMapper mapper;
        private readonly IExpenseDAL _expenseDL;

        public ExpenseBL(IExpenseDAL expenseDL)
        {
            _expenseDL = expenseDL;
            // config זה מופע של המחלקה AutoMapperProfile שנמצא ב-DTO 
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            mapper = config.CreateMapper();
        }

        public async Task<List<ExpenseDTO>> GetByUserId(int id)
        {
            List<Expense> ex =await _expenseDL.GetByUserId(id);
            return mapper.Map<List<Expense>, List<ExpenseDTO>>(ex);
        }

        //public UsersDTO GetById(int id)
        //{
        //    Users user = _userDL.GetById(id);
        //    if (user == null)
        //        return null;
        //    return mapper.Map<Users, UsersDTO>(user);
        //}

        public async Task AddExpense(ExpenseDTO ex)
        {
            // Users user = ConvertToUser(userDTO);
          await  _expenseDL.AddExpense(mapper.Map<ExpenseDTO, Expense>(ex));
        }

        //public bool DeleteUser(int id)
        //{
        //    return _userDL.DeleteUser(id);
        //}

        //public bool UpdateUser(UsersDTO userDTO, int id)
        //{
        //    //User user = ConvertToUser(userDTO);
        //    Users user = mapper.Map<UsersDTO, Users>(userDTO);
        //    return _userDL.UpdateUser(user, id);
        //}

    }
}
