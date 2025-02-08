using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogDesktop_Miftiev_
{
    public class user
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public user(
            string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
