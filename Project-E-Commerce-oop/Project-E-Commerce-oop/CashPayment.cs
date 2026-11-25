using Project_E_Commerce_oop.Interface;
using System;

namespace Project_E_Commerce_oop.Payments
{
    public class CashPayment : IPayment
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} using Cash");
        }
    }
}