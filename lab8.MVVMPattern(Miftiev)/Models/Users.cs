using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8.MVVMPattern_Miftiev_.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Users(int id, string login, string password)
        {
            Id = id;
            Login = login;
            Password = password;
        }
    }
}
