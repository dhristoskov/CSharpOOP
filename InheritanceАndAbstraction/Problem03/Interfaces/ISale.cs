using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem03
{
    internal interface ISale
    {
        string ProductName { get; set; }
        DateTime Date { get; set; }
        decimal Price { get; set; }
    }
}
