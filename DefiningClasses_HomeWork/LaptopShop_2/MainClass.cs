using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopShop_2
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Laptop laptop = new Laptop("Lenovo", 850.40m);
            Console.WriteLine(laptop+"\n");
            Laptop acer = new Laptop("Acer Aspire", 1990.99m, "Acer", "AMD", "Radeon", "1TB", "15.5\" Full HD", "8GB DDR4");
            Console.WriteLine(acer+"\n");
            Laptop dell = new Laptop("Dell Inspiron", 2090.99m, "Dell", "Intel", "nVidia", "1TB", "15.5\" Full HD", "8GB DDR4", "Li-ION 4500 mAh", "6h");         
            Console.WriteLine(dell);
        }
    }
}
