using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem03
{
    internal interface IPerson
    {
        long ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
