using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUnLearningSys
{
    internal class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 2)
                {
                    throw new ArgumentException("Please enter correct First Name!");
                }
                else
                {
                    this.firstName = value;
                }
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 2)
                {
                    throw new ArgumentException("Please enter correct Last Name!");                    
                }
                else
                {
                    this.lastName = value;
                }
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 18 || value > 100)
                {
                    throw new ArgumentException("Please enter correct age!");
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Name: {0} {1}, Age: {2}", this.FirstName, this.LastName, this.Age);
        }
    }
}
