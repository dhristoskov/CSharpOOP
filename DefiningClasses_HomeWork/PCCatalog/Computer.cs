using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCatalog
{
    class Computer
    {
        private string name;
        private decimal totalPrice;
        private List<Component> components;

        public Computer(string name,List<Component>components)
        {
            this.Name = name;
            this.components = components;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Please enter correct name!");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public decimal TotalPrice
        {
            get { return totalPrice = components.Select(x => x.Price).Sum(); }
        }
        public void PrintConfig()
        {
            Console.WriteLine("Computer name: {0}",this.Name);
            components.ForEach(x => Console.WriteLine("Component: {0}, Detail: {1}, Price: {2:f2} BGN", x.Name, x.Details, x.Price));
            Console.WriteLine("Total Price is {0:f2} BGN",this.TotalPrice);
        }
    }
}
