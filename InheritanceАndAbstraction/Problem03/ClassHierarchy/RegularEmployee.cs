using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem03
{
    internal class RegularEmployee : Employee
    {
        public RegularEmployee(string firstName, string lastName, long id, decimal salary, Departments department)
            : base(firstName, lastName, id, salary, department)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
