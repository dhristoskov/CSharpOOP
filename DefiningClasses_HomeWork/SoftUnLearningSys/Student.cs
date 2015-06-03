using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUnLearningSys
{
    internal class Student : Person
    {
        private long studentNum;
        private decimal averageGrade;

        public Student(string firstName, string lastName, int age,long studentNum, decimal averageGrade)
            :base(firstName,lastName,age)
        {
            this.StudentNum = studentNum;
            this.AverageGrade = averageGrade;
        }

        public long StudentNum
        {          
            get { return this.studentNum; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Please enter correct student number!");
                }
                else
                {
                    this.studentNum = value;
                }
            }
        }
        public decimal AverageGrade
        {
            get { return this.averageGrade; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Please enter correct grade!");
                }
                else
                {
                    this.averageGrade = value;
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\n Student Number: {0}, Average Grade: {1}", this.StudentNum, this.AverageGrade);
        }
    }
}
