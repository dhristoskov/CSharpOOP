using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Persons_1
{
    class Person
    {
        private string name;
        private int age;
        private string email;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.email = "No e-mail";
        }
        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 2)
                {
                    throw new ArgumentException("Please enter correct name!");
                    //Console.WriteLine("Please enter correct name!");
                }
                else
                {
                    this.name = value;
                }               
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException("Please enter correct age!");
                    //Console.WriteLine("Please enter correct age");
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                Regex rgx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                if (!rgx.IsMatch(value))
                {
                    throw new ArgumentException("Please enter correct e-mail!");
                    //Console.WriteLine("Please enter correct e-mail");
                    //this.email = "Incorrect address";
                }
                else
                {
                    this.email = value;                   
                }
            }
        }
        public override string ToString()
        {
            return String.Format("Name: {0}, Age: {1}, E-mail: {2}", this.Name, this.Age,this.Email);                    
        }
    }
}
