using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = 0;
           try
           {
                int number = int.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                result = Math.Sqrt(number);
                Console.WriteLine(result);
           }       
           catch (FormatException)
           {
               Console.Error.WriteLine("Enter correct format number!");
           }
           catch (OverflowException)
           {
               Console.Error.WriteLine("The number is too big for integer!");
           }
           catch(ArgumentOutOfRangeException)
           {
               Console.Error.WriteLine("Number can not be negative!");
           }
           finally
           {
               Console.WriteLine("Good bye");
           }
        }
    }
}
