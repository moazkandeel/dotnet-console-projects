using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_E_Commerce_oop.Models
{
    public class User
    {
        public int Id { get; }

        public string Username { get; }

        public string Password { get; }

        public User(int id, string username, string password)
        {
            Id = id;
            Username = username;
            Password = password;
        }
    }
}
