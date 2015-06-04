using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Point3D
{
    public static class Storage
    {
        public static void SaveFile(List<Point3D> path)
        {
            using (StreamWriter writer = new StreamWriter("Points.txt"))
            {
                foreach (var points in path)
                {
                    writer.WriteLine(String.Format("{0} {1} {2}", points.X, points.Y, points.Z));
                }
            }
        }
        public static List<Point3D> LoadFile(string path)
        {
            List<Point3D> newPath = new List<Point3D>();
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    double[] pointsArr = line.Split().Select(double.Parse).ToArray();
                    double pointX = pointsArr[0];
                    double pointY = pointsArr[1];
                    double pointZ = pointsArr[2];

                    newPath.Add(new Point3D(pointX, pointY, pointZ));                  
                }
                return newPath;
            }
        }
    }
}
