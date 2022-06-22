using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class UsersDTO
    {
       public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public string UserPassword { get; set; }
        public int? UserFamilySize { get; set; }

    }
}
