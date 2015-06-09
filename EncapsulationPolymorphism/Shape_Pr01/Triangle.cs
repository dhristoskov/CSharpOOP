using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shape_Pr01
{
    internal class Triangle : BasicShape
    {
        private double A { get; set; }
        private double B { get; set; }
        private double C { get; set; }       

        public Triangle(double a,double b,double c,double width,double height)
        {
            this.A = a;
            this.B = b;
            this.C = c;
            base.Height = height;
            base.Width = width;
        }
        public override void CalculateArea()
        {
            Console.WriteLine((base.Height*base.Width)/2);
        }

        public override void CalculatePerimeter()
        {
            Console.WriteLine(this.A + this.B + this.C);
        }
    }
}
