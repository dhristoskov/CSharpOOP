using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem02
{
    enum Gender
    {
        male,
        female
    }

    internal abstract class Animal : ISoundProducible
    {
        private string name;
        private Gender gender;
        private int age;

        public Animal(string name, Gender gender, int age)
        {
            this.Name = name;
            this.Gender = gender;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.age = value;
            }
        }
        public Gender Gender 
        {
            get { return this.gender; }
            set { this.gender = value; }
        }
        public abstract void ProduceSound();
    }
}
