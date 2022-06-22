using System;
using System.Collections.Generic;
using System.Text;
using DTO;

using DAL;
using DAL.Models;
using AutoMapper;
using System.Threading.Tasks;

namespace BL
{
    public class UsersBL : IUsersBL
    {
        
        IMapper mapper;
        private readonly IUsersDAL _userDL;

        public UsersBL(IUsersDAL userDAL)
        {
            _userDL = userDAL;
        
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();

            });
            mapper = config.CreateMapper();
        }

        public async Task<UsersDTO> GetUser(string password, string email)
        {
            Users user = await _userDL.GetUser(password, email);          
            return mapper.Map<Users, UsersDTO>(user);
        }

        public async Task<UsersDTO> GetById(int id)
        {
            Users user = await _userDL.GetById(id);
            return mapper.Map<Users, UsersDTO>(user);
        }

        public async Task<UsersDTO> AddUser(UsersDTO userDTO)
        {
         Users u= await _userDL.AddUser(mapper.Map<UsersDTO, Users>(userDTO));
            return mapper.Map<Users, UsersDTO>(u);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _userDL.DeleteUser(id);
        }

        public async Task<bool> UpdateUser(UsersDTO userDTO, int id)
        {
            
            Users user = mapper.Map<UsersDTO, Users>(userDTO);
            return await _userDL.UpdateUser(user, id);
        }


    }
}
