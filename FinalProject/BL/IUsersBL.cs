using DAL.Models;
using DTO;
using System.Threading.Tasks;

namespace BL
{
    public interface IUsersBL
    {
        Task<UsersDTO> AddUser(UsersDTO userDTO);
        Task<bool> DeleteUser(int id);
        Task<UsersDTO> GetUser(string password, string email);
        Task<bool> UpdateUser(UsersDTO userDTO, int id);
        Task<UsersDTO> GetById(int id);
    }
}