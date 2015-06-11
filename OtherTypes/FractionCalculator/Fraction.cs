using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculator
{
    internal struct Fraction
    {
        public long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator) : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator
        {
            get { return this.numerator; }
            set { this.numerator = value; }
        }

        public long Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentOutOfRangeException("Denominator can not be zero!!!");
                }
                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction x = new Fraction();
            x.Numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            x.Denominator = a.Denominator * b.Denominator;
            return x;
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction x = new Fraction();
            x.Numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            x.Denominator = a.Denominator * b.Denominator;
            return x;
        }

        public override string ToString()
        {
            return ((Numerator / (decimal)Denominator)).ToString();
        }
    }
}

