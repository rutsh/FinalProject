using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
     public class ExpenseDAL : IExpenseDAL
    {
        private readonly EconomyContext _context;
        public ExpenseDAL(EconomyContext context)
        {
            _context = context;
        }

        public async Task<List<Expense>> GetByUserId(int id)
        {
            List<Expense> expenses =await _context.Expense.Where(e => e.ExpenseUser == id).ToListAsync();
            return expenses;

        }

        //public Users GetUser(string password, string name)
        //{
        //    Users user = _context.Users.
        //        Where(x => x.UserPassword.Equals(password) && x.UserName.Equals(name)).FirstOrDefault();
        //    return user;
        //}
        public async Task AddExpense(Expense e)
        {
            _context.Expense.Add(e);
          await  _context.SaveChangesAsync();
        }

        ////צריך לוודא שמוחקים כל מה שקשור לאוביקט זה 
        //public bool DeleteUser(int id)
        //{
        //    try
        //    {
        //        Users user = _context.Users.Where(x => x.UserId == id).FirstOrDefault();
        //        _context.Users.Remove(user);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public bool UpdateUser(Users user, int id)
        //{
        //    try
        //    {
        //        Users currentUser = _context.Users.Where(x => x.UserId == id).FirstOrDefault();
        //        user.UserId = id;
        //        _context.Entry(currentUser).CurrentValues.SetValues(user);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
    }
}
