using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfKurtovoKonare
{
    internal class Mortgage : Account
    {
        public Mortgage (Customer customer, decimal balance, decimal interest)
        {
            base.Customer = customer;
            base.Balance = balance;
            base.InterestRate = interest;
        }      
        public override void CalcInterestRate(int months)
        {         
            if (Customer.Type == AccountType.Companies)
            {
                if (months <= 12)
                {
                    base.Balance -= (base.Balance * (1 + base.InterestRate * months))/2;
                }
                else
                {
                    base.Balance -= (base.Balance * (1 + base.InterestRate * months - 12)) - 
                        (base.Balance * (1 + base.InterestRate * 12)) / 2; 
                }
            }
            else
            {
                if (months > 6)
                {
                    base.Balance -= (base.Balance * (1 + base.InterestRate * months - 6));
                }
            }
        }
    }
}
