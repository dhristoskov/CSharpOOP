using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass
{
    delegate void PropartyEventHandler(PropertyChangedEventArgs e);

    class Student
    {
        private string name;
        private int age;
        public event PropartyEventHandler EventChange;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;

        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Student's age can not be negative!");
                }
                this.OnChanged(new PropertyChangedEventArgs("Age", this.Age.ToString(), value.ToString()));
                this.age = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Student's name can not be null or empty!");
                }
                this.OnChanged(new PropertyChangedEventArgs("Name", this.Name, value));
                this.name = value;
            }
        }
        protected virtual void OnChanged(PropertyChangedEventArgs arg)
        {
            if (this.EventChange!=null)
            {
                this.EventChange(arg);
            }
        }
    }
}
