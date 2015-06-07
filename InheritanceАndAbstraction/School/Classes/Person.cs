using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    internal class Person : IPerson
    {
        private string firstName;
        private string lastName;
        private string details;

        public Person(string firstName,string lastName,string details)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Details = details;
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

        public string Details
        {
            get { return this.details; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    this.details = "N/A";
                }
                else
                {
                    this.details = value;
                }               
            }
        }
        public override string ToString()
        {
            return String.Format("Name:{0} {1}, Details:{2}", this.FirstName, this.LastName, this.Details);
        }
    }
}
