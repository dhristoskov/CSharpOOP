using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    internal interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Details { get; set; }
    }
}
