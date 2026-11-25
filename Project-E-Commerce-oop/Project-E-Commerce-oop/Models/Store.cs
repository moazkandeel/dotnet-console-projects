using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_E_Commerce_oop.Models
{
    public class Store
    {
        public List<Product> Products { get; }

        public List<User> Users { get; }

        public Store()
        {
            Products = new List<Product>();
            Users = new List<User>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }

        public void Register(User user)
        {
            bool userExists = Users.Any(
                u => u.Username.Equals(
                    user.Username,
                    StringComparison.OrdinalIgnoreCase));

            if (userExists)
                throw new InvalidOperationException("Username already exists.");

            Users.Add(user);
        }

        public User? Login(string username, string password)
        {
            return Users.FirstOrDefault(
                u =>
                    u.Username == username &&
                    u.Password == password);
        }
    }
}