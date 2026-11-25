using Project_E_Commerce_oop.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_E_Commerce_oop.Payments
{
    public class PayPalPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using PayPal");
        }
    }
}
