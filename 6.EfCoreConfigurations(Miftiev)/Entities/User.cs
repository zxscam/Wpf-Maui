using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreConfigurations_Miftiev_.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName {  get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(
            string lastName,
            string firstName,
            string middleName,
            string username,
            string password)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Username = username;    
            Password = password;    
        }
    }
}
