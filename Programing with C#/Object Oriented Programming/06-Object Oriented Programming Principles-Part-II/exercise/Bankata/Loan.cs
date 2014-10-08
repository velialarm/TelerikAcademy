using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bankata
{
    public class Loan : Accounts
    {
        public Loan(Customers customer, decimal balance, decimal interestRate, int numberOfMounts)
            : base(customer, balance, interestRate, numberOfMounts)
        {         
        }
        public override void deposit(decimal money)
        {
            this.Balance += money;   
        }
        public override decimal calculate()
        {
            if (NumberOfMounts <= 3 && Customer is Individuals) {
                return 0;
            }
            else if (NumberOfMounts <= 2 && Customer is Companies)
            {
                 return 0;
            }else{
                 return InterestRate * NumberOfMounts;
            }
        }
    }
}
