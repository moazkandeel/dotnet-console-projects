using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project_E_Commerce_oop.Models
{
    public class CartItem
    {
        public Product Product { get; }

        public int Quantity { get; private set; }

        public CartItem(Product product, int quantity)
        {
            if (product is null)
                throw new ArgumentNullException(nameof(product));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            Product = product;
            Quantity = quantity;
        }

        public void IncreaseQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            Quantity += quantity;
        }

        public void DecreaseQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero");

            if (quantity > Quantity)
                throw new InvalidOperationException("Not enough quantity in cart");

            Quantity -= quantity;
        }
    }
}
