using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons_1
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("E-mail:");
            string email = Console.ReadLine();
            Console.Write("Age:");
            int age = int.Parse(Console.ReadLine());

            Person person = new Person(name, age);
            Console.WriteLine("First Constructor");
            Console.WriteLine(person);

            Person secondPerson = new Person(name, age, email);
            Console.WriteLine("SecondPerson Constructor");
            Console.WriteLine(secondPerson);
        }
    }
}
