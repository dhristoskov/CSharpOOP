using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    public static class DistanceCalculator
    {
        public static double CalcDistance(Point3D pointA, Point3D pointB)
        {
            double deltaX = pointB.X - pointA.X;
            double deltaY = pointB.Y - pointA.Y;
            double deltaZ = pointB.Z - pointA.Z;

            double distance = (double)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
            return distance;
        }
    }
}
