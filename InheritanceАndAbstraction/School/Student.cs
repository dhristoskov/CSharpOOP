using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    internal class Student : Person, IStudent
    {
        private string classNumber;

        public Student(string firstName, string lastName, string details,string classNumber)
            : base(firstName, lastName, details)
        {
            this.ClassNumber = classNumber;
        }
        public string ClassNumber
        {
            get { return this.classNumber; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                this.classNumber = value;
            }
        }
    }
}
