using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfKurtovoKonare
{
    internal abstract class Account : IAccount
    {
        private decimal interestRate;
        public Customer Customer { get; set; }
        public decimal Balance { get; set; }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.interestRate = value;
            }
        }
        public decimal DepositMoney(decimal money)
        {
            return this.Balance += money;
        }
        public abstract void CalcInterestRate(int months);
    }
}
