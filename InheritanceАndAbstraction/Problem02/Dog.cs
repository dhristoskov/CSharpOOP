using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem02
{
    internal class Dog : Animal
    {
        public Dog(string name, Gender gender, int age)
            : base(name, gender, age)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Bau Bau Bauuu!");
        }
    }
}
