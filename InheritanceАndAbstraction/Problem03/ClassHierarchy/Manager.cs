using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem03
{
    internal class Manager : Employee, IManager
    {
        private List<Employee> employees;

        public Manager(string firstName, string lastName, long id, decimal salary, Departments department, List<Employee> employees)
            : base(firstName, lastName, id, salary, department)
        {
            this.Employees = employees;
        }

        public List<Employee> Employees
        {
            get { return this.employees; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.employees = value;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" Employeses under command:");
            foreach (var employee in this.employees)
            {
                sb.AppendLine(employee.ToString());
            }
            return base.ToString() + sb.ToString();
        }
       
    }
}
