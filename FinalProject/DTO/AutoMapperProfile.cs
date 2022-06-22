using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DAL.Models;
namespace DTO
{
    public class AutoMapperProfile : AutoMapper.Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<CategoriesDTO, Categories>();
            CreateMap<Categories, CategoriesDTO>();

            CreateMap<UsersDTO, Users>();
            CreateMap<Users, UsersDTO>();

            CreateMap<ExpenseDTO, Expense>();
            CreateMap<Expense, ExpenseDTO>();

            CreateMap<IncomeDTO, Income>();
            CreateMap<Income, IncomeDTO>();
             
            CreateMap<FixedExpenseDTO, FixedExpense>();
            CreateMap<FixedExpense, FixedExpenseDTO>();

            CreateMap<FixedIncomeDTO, FixedIncome>();
            CreateMap<FixedIncome, FixedIncomeDTO>();
        }
    }
}
