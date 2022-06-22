using DAL.Models;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUsersDAL
    {
        Task<Users> AddUser(Users user);
        Task<bool> DeleteUser(int id);
        Task<Users> GetUser(string password, string email);
        Task<bool> UpdateUser(Users user, int id);

        Task<Users> GetById(int id);
       
    }
}