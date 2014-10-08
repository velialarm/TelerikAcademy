using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bankata
{
    public class Mortage : Accounts
    {
        public Mortage(Customers customer, decimal balance, decimal interestRate, int numberOfMounts)
            : base(customer, balance, interestRate, numberOfMounts)
        {         
        }
        public override void deposit(decimal money)
        {
            Balance += money;
        }
        public override decimal calculate()
        {
            if(NumberOfMounts <= 12 && Customer is Companies){
                return (InterestRate / 2) * 12;
            }
            else if (NumberOfMounts <= 6 && Customer is Individuals)
            {
                return 0;
            }
            else {
                return InterestRate * NumberOfMounts;
            }
        }
    }
}
