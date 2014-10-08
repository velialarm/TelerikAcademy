using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bankata
{
    public class Deposit : Accounts
    {
        public Deposit(Customers customer, decimal balance, decimal interestRate, int numberOfMounts)
            : base(customer, balance, interestRate, numberOfMounts)
        {         
        }
        public override void deposit(decimal money)
        {
            Balance += money;
        }
        public override void draw(decimal money)
        {
            if (Balance > money)
            {
                Balance -= money;
            }
        }
        public override decimal calculate()
        {
            if (Balance <= 1000)
            {
                return 0;
            }
            else {
                return NumberOfMounts * InterestRate;
            }
        }
    }
}
