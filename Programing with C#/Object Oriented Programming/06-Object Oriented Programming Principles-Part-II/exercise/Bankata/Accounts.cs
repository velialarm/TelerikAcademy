using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bankata
{
    public abstract class Accounts
    {
        private Customers customer;
        private decimal balance;
        private decimal interestRate;
        private int numberOfMounts;

        public Accounts(Customers customer, decimal balance, decimal interestRate, int numberOfMounts)
        {
            this.customer = customer;
            this.balance = balance;
            this.interestRate = interestRate;
            this.numberOfMounts = numberOfMounts;
        }
        public virtual void deposit(decimal money) { 
        }
        public virtual void draw(decimal money) { 
        }
        public virtual decimal calculate() {
            return InterestRate * NumberOfMounts;
        }
        public Customers Customer
        {
            get { return this.customer; }
            set { this.customer = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            set { this.interestRate = value; }
        }
        public virtual decimal InterestAmountForPeriod(int number_of_mounths) {
            return InterestRate * NumberOfMounts;
        }

        public int NumberOfMounts
        {
            get { return numberOfMounts; }
            set { numberOfMounts = value; }
        }
        
    }
}
