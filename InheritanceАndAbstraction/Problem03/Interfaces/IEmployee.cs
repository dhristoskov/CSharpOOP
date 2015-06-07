using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem03
{
    internal interface IEmployee
    {
        decimal Salary { get; set; }
        Departments Department { get; set; }
    }
}
