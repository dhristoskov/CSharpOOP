using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape_Pr01
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(20, 20, 10, 20, 15);
            Rectangle rectangle = new Rectangle(20, 8);
            Circle circle = new Circle(8);
            List<IShape> shapes = new List<IShape>();
            shapes.Add(triangle);
            shapes.Add(rectangle);
            shapes.Add(circle);

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.GetType()); 
                shape.CalculateArea();
                shape.CalculatePerimeter();
            }
        }
    }
}
