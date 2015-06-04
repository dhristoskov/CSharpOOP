using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray
{
    class MainClass
    {
        static void Main(string[] args)
        {
            BitArray number = new BitArray(16);
            number[0] = 1;
            number[7] = 1;
            number[9] = 1;
            number[12] = 1;
            Console.WriteLine(number);
        }
    }
}
