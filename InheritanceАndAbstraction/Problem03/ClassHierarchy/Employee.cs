using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem03
{
    internal class Employee : Person, IEmployee
    {
        private decimal salary;
        private Departments department;

        public Employee(string firstName, string lastName, long id, decimal salary, Departments department)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.salary = value;
            }
        }

        public Departments Department
        {
            get { return this.department; }
            set { this.department = value; }
        }
        public override string ToString()
        {
            return base.ToString() + String.Format("Department:{0}, Salary: {1:0.00}", this.Department, this.Salary);
        }
    }
}
