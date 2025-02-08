using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicShop_Miftiev_.Entities
{
    public class UsersEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; } 

        public UsersEntity() { }
        public UsersEntity(
            string login,
            string password)
        {
            Login = login;
            Password = password;
        }
    }
}
