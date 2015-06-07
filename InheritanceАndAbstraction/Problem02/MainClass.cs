using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            try
            {
                animals = new List<Animal>()
                {
                    new Dog("Sharo",Gender.male,3),
                    new Dog("Sara",Gender.female,4),
                    new Dog("Scooby-Doo",Gender.male,2),
                    new Dog("Lassie",Gender.female,5),
                    new Dog("Rex",Gender.male,1),
                    new Kitten("Luna",Gender.female,1),
                    new Kitten("Puffy",Gender.female,1),
                    new Tomcat("Garfield",Gender.male,9),
                    new Tomcat("Tommy",Gender.male,5),
                    new Kitten("Calie",Gender.female,3),
                    new Kitten("Poppy",Gender.female,3),
                    new Tomcat("Blacky",Gender.male,6),
                    new Tomcat("Silvester",Gender.male,4)
                };
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Empty name, please enter a nema!");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Years can not be negative number!");
            }
            foreach (var animal in animals)
            {
                Console.Write("Name: {0}, Gender {1}, {2} years old, said: ",animal.Name,animal.Gender,animal.Age);
                animal.ProduceSound();
            }
            var dogs = animals.Where(x => x.GetType() == typeof(Dog)).Select(x => x.Age).Average();
            var kittens = animals.Where(x => x.GetType() == typeof(Kitten)).Select(x => x.Age).Average();
            var tomcats = animals.Where(x => x.GetType() == typeof(Tomcat)).Select(x => x.Age).Average();
            Console.WriteLine("Average Dogs age in the group is: {0} years",dogs);
            Console.WriteLine("Average Kittens age in the group is: {0} years", kittens);
            Console.WriteLine("Average Tomcats age in the group is: {0} years", tomcats);

        }
    }
}
