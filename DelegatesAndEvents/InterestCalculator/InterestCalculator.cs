using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalculator
{
    /*In main class I'm using 
     * Action<> and Func<> so I 
     * don't need to declare delegate
     */

    //public delegate decimal CalculateInterest(decimal money,decimal interestRate,int years);

    class InterestCalculator
    {
        private decimal money;
        private decimal interestRate;
        private int years;
        //private CalculateInterest result;

        public InterestCalculator(decimal money,decimal interestRate,int years)
        {
            this.Money = money;
            this.InterestRate = interestRate;
            this.Years = years;
            //this.Result = result;
        }

        public decimal Money 
        {
            get { return this.money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Money value can not be negative!");
                }
                this.money=value;
            }
        }

        public decimal InterestRate 
        {
            get { return this.interestRate; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest Rate can not be negative!");
                }
                this.interestRate=value;
            } 
        }

        public int Years 
        {
            get { return this.years; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Period can not be negative!");
                }
                this.years = value;
            }
        }
    }
}
