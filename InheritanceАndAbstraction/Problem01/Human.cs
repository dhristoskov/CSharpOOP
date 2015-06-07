using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem01
{
    internal abstract class Human
    {
        private string firstName;
        private string lastName;
   
        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                this.lastName = value;
            }
        }
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                this.firstName = value;
            }
        }
        public override string ToString()
        {
            return String.Format("Name:{0} {1}", this.FirstName, this.LastName);
        }
    }
}
