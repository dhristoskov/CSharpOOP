using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            Point3D pointA = new Point3D(0, 0, 0);
            Point3D pointB = new Point3D(1, 1, 1);

            Console.WriteLine(pointA);
            Console.WriteLine(pointB);
            Point3D a = Point3D.StartPoint;
            Console.WriteLine(a);

            double result = DistanceCalculator.CalcDistance(pointA, pointB);
            Console.WriteLine(result);

            Path3D path = new Path3D(new List<Point3D>()
            {
                new Point3D(0,0,0),
                new Point3D(1,2,3),
                new Point3D(2,2,2),
                new Point3D(1,4,5),
                new Point3D(4,7,8)
           });
            Storage.SaveFile(path.ReturnPoints);
            var load = Storage.LoadFile("Points.txt");
            Path3D secPath = new Path3D(load);         
        }
    }
}
