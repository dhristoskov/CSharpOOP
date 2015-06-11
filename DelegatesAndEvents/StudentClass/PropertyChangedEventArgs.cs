using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass
{
    class PropertyChangedEventArgs : EventArgs
    {
        public string PropertyName { get; private set; }
        public string OldValue { get; private set; }
        public string NewValue { get; private set; }

        public PropertyChangedEventArgs(string propertyName, string oldValue, string newValue)
        {
            this.PropertyName = propertyName;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }
    }
}
