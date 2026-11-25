using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_E_Commerce_oop.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; }

        public Cart()
        {
            Items = new List<CartItem>();
        }

        public void AddProduct(Product product, int quantity)
        {
            if (product is null)
                throw new ArgumentNullException(nameof(product));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            if (quantity > product.StockQuantity)
                throw new InvalidOperationException("Not enough stock");

            var existingItem = Items.FirstOrDefault(x => x.Product.Id == product.Id);

            if (existingItem != null)
            {
                existingItem.IncreaseQuantity(quantity);
            }
            else
            {
                Items.Add(new CartItem(product, quantity));
            }

            product.ReduceStock(quantity);
        }

        public void RemoveProduct(Product product, int quantity)
        {
            if (product is null)
                throw new ArgumentNullException(nameof(product));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            var existingItem = Items.FirstOrDefault(x => x.Product.Id == product.Id);

            if (existingItem == null)
                throw new InvalidOperationException("Product not found in cart");

            if (quantity >= existingItem.Quantity)
            {
                product.AddStock(existingItem.Quantity);
                Items.Remove(existingItem);
            }
            else
            {
                existingItem.DecreaseQuantity(quantity);
                product.AddStock(quantity);
            }
        }

        public decimal GetTotalPrice()
        {
            return Items.Sum(x => x.Product.Price * x.Quantity);
        }
    }
}