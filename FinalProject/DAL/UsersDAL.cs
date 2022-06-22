using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using DAL.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class UsersDAL : IUsersDAL
    {
       
        private readonly EconomyContext _context;
        public UsersDAL(EconomyContext context)
        {
            _context = context;
        }

        public async Task<Users> GetById(int id)
        {
            Users user = await _context.Users.Where(x => x.UserId==id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<Users> GetUser(string password, string email)
        {
            Users user =await _context.Users.Where(x => x.UserPassword.Equals(password) && x.UserMail.Equals(email)).FirstOrDefaultAsync();
            return user;
        }
        public async Task<Users> AddUser(Users user)
        {
            Users u = await _context.Users.Where(u => u.UserName.Equals(user.UserName) && u.UserPassword.Equals(user.UserPassword)).FirstOrDefaultAsync();
            if (u != null)
                throw new Exception("userName and password already exist");
            else
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return  await _context.Users.Where(u => u.UserName.Equals(user.UserName) && u.UserPassword.Equals(user.UserPassword)).FirstOrDefaultAsync();
            }
        }

        //צריך לוודא שמוחקים כל מה שקשור לאוביקט זה 
        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                Users user =await _context.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUser(Users user, int id)
        {
            try
            {
                Users currentUser =await _context.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
                user.UserId = id;
                _context.Entry(currentUser).CurrentValues.SetValues(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
