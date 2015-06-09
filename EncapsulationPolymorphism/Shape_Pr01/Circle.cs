using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shape_Pr01
{
    internal class Circle : IShape
    {
        public double Radius { get; private set; }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public void CalculateArea()
        {
            Console.WriteLine(Math.PI*this.Radius*this.Radius);
        }

        public void CalculatePerimeter()
        {
            Console.WriteLine(2*Math.PI*this.Radius);
        }
    }
}
