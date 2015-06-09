using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shape_Pr01
{
    internal abstract class BasicShape : IShape
    {
        protected double Width { get; set; }
        protected double Height { get; set; }

        public abstract void CalculateArea();
        public abstract void CalculatePerimeter();       
    }
}
