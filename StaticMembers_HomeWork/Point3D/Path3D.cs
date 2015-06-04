using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    public class Path3D
    {
        private List<Point3D> points= new List<Point3D>();

        public Path3D(List<Point3D> points)
        {
            this.points = points;
        }
        public List<Point3D> ReturnPoints
        {
            get { return points; }
        }      
    }
}
