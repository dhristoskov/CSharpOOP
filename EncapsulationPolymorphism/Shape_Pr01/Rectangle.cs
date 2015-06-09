using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shape_Pr01
{
    internal class Rectangle : BasicShape
    {
        public Rectangle(double width,double heigth)           
        {
            base.Width = width;
            base.Height = heigth;
        }
        public override void CalculateArea()
        {
            Console.WriteLine(base.Width * base.Height);
        }

        public override void CalculatePerimeter()
        {
            Console.WriteLine(2 * (base.Width + base.Height));
        }
    }
}
