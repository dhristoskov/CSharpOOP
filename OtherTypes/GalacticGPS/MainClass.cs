using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticGPS
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            Location location = new Location(125.56, 255.12, Planets.Mercury);
            Console.WriteLine(location);
        }
    }
}
