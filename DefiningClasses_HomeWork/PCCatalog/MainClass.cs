using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCatalog
{
    class MainClass
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>();

            Computer computer1 = new Computer("Terminator", new List<Component>() 
            {
                new Component( "Motherboard", 80.00m),
                new Component("Processor",250.90m,"Intel Core I5"),
                new Component("RAM Memory",80.90m,"8GB DDR4"),
                new Component("Hard Drive", 150.00m),
                new Component("Graphics Card",550.25m,"nVidia")
            });
            computers.Add(computer1);
            Computer computer2 = new Computer("Turtle", new List<Component>() 
            {
                new Component( "Motherboard", 50.00m),
                new Component("Processor",180.60m,"Intel Dual Core"),
                new Component("RAM Memory",40.40m,"4GB DDR3"),
                new Component("Hard Drive", 150.00m,"500GB"),
                new Component("Graphics Card",150.25m,"nVidia")
            });
            computers.Add(computer2);
            Computer computer3 = new Computer("Falcon", new List<Component>() 
            {
                new Component( "Motherboard", 350.00m),
                new Component("Processor",700.99m,"Intel Core I7"),
                new Component("RAM Memory",500.40m,"16GB DDR5"),
                new Component("Hard Drive", 750.00m,"500GB SSD + 1TB"),
                new Component("Graphics Card",1150.25m,"nVidia")
            });
            computers.Add(computer3);
            foreach (var computer in computers.OrderByDescending(x => x.TotalPrice))
            {
                computer.PrintConfig();
            }
        }
    }
}
