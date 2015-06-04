using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterNumbers_2
{
    class EnterNumbers_2
    {
        private static List<int> numbers = new List<int>();
        private const int start = 1;
        private const int end = 100;

        private static int ReadNumbers(string num)
        {            
            int number;
            if (!int.TryParse(num, out number))
            {
                throw new FormatException();
            }
            else if (number <= start || number > end)
            {
                throw new ArgumentOutOfRangeException();
            }
            return number;
        }
        private static void PrintList()
        {
            numbers.Sort();
            Console.WriteLine("Your 10 numbers");
            Console.WriteLine(String.Join(", ",numbers));
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    int number = ReadNumbers(Console.ReadLine());
                    numbers.Add(number);
                }
                catch (FormatException)
                {
                    Console.Error.WriteLine("Enter the number in correct format!");
                    i--;
                }              
                catch (ArgumentOutOfRangeException)
                {
                    Console.Error.WriteLine("End must be greater than start");
                    i--;
                }
            }
            PrintList();      
        }       
    }
}
