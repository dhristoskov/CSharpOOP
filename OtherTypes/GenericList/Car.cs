using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class Car : IComparable<Car>
    {
        public string Type { get; private set; }
        public string Model { get; private set; }
        public decimal Price { get; private set; }

        public Car(string type, string model, decimal price)
        {
            this.Type = type;
            this.Model = model;
            this.Price = price;
        }

        public override string ToString()
        {
            return String.Format("Type: {0},Model: {1}, Price: {2:f2}", this.Type, this.Model, this.Price);
        }
        public int CompareTo(Car car)
        {
            return this.Type.CompareTo(car.Type);
        }
    }
}
