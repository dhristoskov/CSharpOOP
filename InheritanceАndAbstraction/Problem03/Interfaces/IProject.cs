using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem03
{
    internal interface IProject
    {
        string ProjectName { get; set; }
        DateTime StartDate { get; set; }
        string Details { get; set; }
        States State { get; set; }

        void CloseProject();
    }
}
