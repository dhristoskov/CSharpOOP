using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem01
{
    internal class Student : Human
    {
        private string facultyNum;

        public Student(string firstName, string lastName, string facultyNum)
            :base (firstName,lastName)
        {
            this.FacultyNum = facultyNum;
        }

        public string FacultyNum
        {
            get { return this.facultyNum; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                else if (value.Length < 5 || value.Length > 10)
                {
                    throw new FormatException();
                }
                this.facultyNum = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + String.Format(", Student ID: {0}", this.FacultyNum);
        }
    }
}
