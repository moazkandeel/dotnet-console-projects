using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_E_Commerce_oop.Models
{
    public class Customer : User
    {
        public Cart Cart { get; }

        public Customer(int id, string username, string password)
            : base(id, username, password)
        {
            Cart = new Cart();
        }
    }
}
