using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalculator
{
    public delegate decimal CalculateInterest(decimal money,decimal interestRate,int years);

    class InterestCalculator
    {
        private decimal money;
        private decimal interestRate;
        private int years;
        public CalculateInterest Result { get; set; }

        public InterestCalculator(decimal money,decimal interestRate,int years,CalculateInterest result)
        {
            this.Money = money;
            this.InterestRate = interestRate;
            this.Years = years;
            this.Result = result;
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
        public override string ToString()
        {
            return String.Format("{0:f4}", this.Result(this.Money, this.InterestRate, this.Years));
        }
    }
}
