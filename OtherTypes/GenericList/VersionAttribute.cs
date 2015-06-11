using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    internal class VersionAttribute : Attribute
    {
        public int Minor { get; private set; }
        public int Major { get; private set; }

        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }
        public override string ToString()
        {
            return String.Format("Version {0}.{1}", this.Major, this.Minor);
        }
    }
}
