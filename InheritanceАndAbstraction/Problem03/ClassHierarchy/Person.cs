using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem03
{
    internal class Person : IPerson
    {
        private long id;
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName, long id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ID = id;
        }

        public long ID
        {
            get
            {return this.id;}
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.id = value;
            }
        }
        public string FirstName
        {
            get
            {return this.firstName;}
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
            get
            { return this.lastName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                this.lastName = value;
            }
        }
        public override string ToString()
        {
            return String.Format("Name:{0} {1},ID: {2}", this.FirstName, this.LastName, this.ID);
        }
    }
}
