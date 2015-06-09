using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOfKurtovoKonare
{
    internal class Customer
    {
        private string firstName;
        private string lastName;
        public AccountType Type { get; set; }      

        public Customer(string firstName, string lastName,AccountType type)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Type = type;
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
    }
}
