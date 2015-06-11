using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class MainClass
    {
        static void Main(string[] args)
        {
            //Printing  -  Genreic List Version Atribute  - Problem.04
            var result = typeof(GenericList<int>).GetCustomAttributes(true).First();
            Console.WriteLine(result);
            
            GenericList<Car> cars = new GenericList<Car>();

            Car ferrari = new Car("Ferrari", "F360", 155000);
            cars.Add(ferrari);
            Car alfa = new Car("Alfa", "Spider", 95000);
            cars.Add(alfa);
            Car mercedes = new Car("Mercedes", "AMG SL65", 135000);
            cars.Add(mercedes);
            Car lada=new Car("Lada","1500",2500);

            Console.WriteLine(cars[0]);
            Console.WriteLine(cars[1]);
            Console.WriteLine(cars[2]);
            Console.WriteLine("List size {0}",cars.Size);
            Console.WriteLine("List capacity {0}",cars.Capacity);
            
            cars.InsertAt(lada, 2);
            Console.WriteLine(cars[2]);
            Console.WriteLine("List size {0}", cars.Size);
            Console.WriteLine(cars.Contains(ferrari));           
        }
    }
}
