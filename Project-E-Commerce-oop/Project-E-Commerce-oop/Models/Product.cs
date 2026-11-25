using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project_E_Commerce_oop.Models
{
    public class Product
    {
        public int Id { get; }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public int StockQuantity { get; private set; }

        public Product(int id, string name, decimal price, int stockQuantity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Invalid Name");

            if (price <= 0)
                throw new ArgumentException("Invalid Price");

            if (stockQuantity < 0)
                throw new ArgumentException("Invalid Stock");

            Id = id;
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
        }

        public void AddStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            StockQuantity += quantity;
        }

        public void ReduceStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            if (quantity > StockQuantity)
                throw new InvalidOperationException("Out Of Stock");

            StockQuantity -= quantity;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Invalid Name");

            Name = name;
        }

        public void UpdatePrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Invalid Price");

            Price = price;
        }
    }
}
