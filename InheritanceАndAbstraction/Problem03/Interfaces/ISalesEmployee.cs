﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem03
{
    internal interface ISalesEmployee
    {
        List<Sale> Sales { get; set; }
    }
}
