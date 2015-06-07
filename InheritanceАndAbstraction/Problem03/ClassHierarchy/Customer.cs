using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem03
{
    internal class Customer : Person,ICustomer
    {
        decimal totalMoneySpent;

        public Customer(string firstName, string lastName, long id, decimal totalMoneySpent)
            :base(firstName,lastName,id)
        {
            this.TotalMoneySpent = totalMoneySpent;
        }
        public decimal TotalMoneySpent
        {
            get { return this.totalMoneySpent; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.totalMoneySpent = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + String.Format("Spent money:{0}", this.TotalMoneySpent);
        }
    }
}
