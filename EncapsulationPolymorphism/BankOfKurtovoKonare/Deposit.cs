using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfKurtovoKonare
{
    internal class Deposit : Account
    {
        public Deposit(Customer customer, decimal balance, decimal interest)
        {
            base.Customer = customer;
            base.Balance = balance;
            base.InterestRate = interest;
        }      
        public decimal Withdraw(decimal money)
        {
            return base.Balance -= money;
        }

        public override void CalcInterestRate(int months)
        {
            if (base.Balance > 1000)
            {
                base.Balance = base.Balance * (1 + base.InterestRate * months);
            }         
        }
    }
}
            
