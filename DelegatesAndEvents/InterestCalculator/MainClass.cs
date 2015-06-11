using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestCalculator
{
    class MainClass
    {
        static decimal GetSimpleInterest(decimal money, decimal interestRate, int years)
        {
            return money * (1 + (interestRate / 100) * years);
        }

        static decimal GetCompoundInterest(decimal money, decimal interestRate, int years)
        {
            return money * (decimal)Math.Pow((double)(1 + (interestRate / 100) / 12), years * 12);
        }

        static void Main(string[] args)
        {

            //Using class instance
            InterestCalculator simple = new InterestCalculator(500, 5.6m, 10, GetCompoundInterest);
            Console.WriteLine(simple);
            InterestCalculator compound = new InterestCalculator(2500, 7.2m, 15, GetSimpleInterest);
            Console.WriteLine(compound);

            //Func delegate
            Func<decimal, decimal, int, decimal> firstDelegate = (GetCompoundInterest);
            Console.WriteLine("{0:f4}", firstDelegate(500, 5.6m, 10));
            Func<decimal, decimal, int, decimal> secondDelegate = (GetSimpleInterest);
            Console.WriteLine("{0:f4}", secondDelegate(2500, 7.2m, 15));


            //Action delegate
            Action<decimal, decimal, int> actionDelegateOne = (money, interestRate, years) => Console.WriteLine("{0:f4}",GetCompoundInterest(money,interestRate, years));
            actionDelegateOne(500, 5.6m, 10);
            Action<decimal, decimal, int> actionDelegateTwo = (money, interestRate, years) => Console.WriteLine("{0:f4}", GetSimpleInterest(money, interestRate, years));
            actionDelegateTwo(2500, 7.2m, 15);
        }
    }
}
