using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculator
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            try
            {
                Fraction a = new Fraction(22, 7);
                Fraction b = new Fraction(40, 4);
                Fraction result = a + b;
                Console.WriteLine(result.Numerator);
                Console.WriteLine(result.Denominator);
                Console.WriteLine(result);
            }
            catch (ArgumentOutOfRangeException exc)
            {
                Console.Error.WriteLine(exc.Message);
            }         
        }
    }
}
