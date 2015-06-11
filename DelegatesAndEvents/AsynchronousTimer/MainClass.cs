using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousTimer
{
    class MainClass
    {
        static void FirstStram(string a)
        {
            Console.WriteLine("First -- {0} ticks left",a);
        }
        static void SecondStream(string a)
        {
            Console.WriteLine("Second -- {0} ticks left", a);
        }
        static void ThirdStream(string a)
        {
            Console.WriteLine("Third -- {0} ticks left", a);
        }

        static void Main(string[] args)
        {
            AsyncTimer first = new AsyncTimer(1000, 10, FirstStram);
            first.Start();
            AsyncTimer second = new AsyncTimer(750, 15, SecondStream);
            second.Start();
            AsyncTimer third = new AsyncTimer(550, 20, ThirdStream);
            third.Start();
        }
    }
}
