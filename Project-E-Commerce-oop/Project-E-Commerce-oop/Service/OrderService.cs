using Project_E_Commerce_oop.Interface;
using Project_E_Commerce_oop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_E_Commerce_oop.Services
{
    public class OrderService
    {
        public void Checkout(Cart cart, IPayment payment)
        {
            decimal totalPrice = cart.GetTotalPrice();

            payment.Pay(totalPrice);
        }
    }
}
