using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project_E_Commerce_oop.Models
{
    public class Order
    {
        public int Id { get; }

        public List<CartItem> Items { get; }

        public decimal TotalPrice { get; }

        public string PaymentMethod { get; }

        public Order(
            int id,
            List<CartItem> items,
            decimal totalPrice,
            string paymentMethod)
        {
            Id = id;
            Items = items;
            TotalPrice = totalPrice;
            PaymentMethod = paymentMethod;
        }
    }
}