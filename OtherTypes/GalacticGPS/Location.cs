using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticGPS
{
    internal struct Location
    {
        public double Latitude;
        public double Longitude;
        public Planets Planet;

        public Location(double latitude, double longitude, Planets planet)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public override string ToString()
        {
            return String.Format("Latitude: {0}, Longitude: {1}, Loacation: {2}", this.Latitude, this.Longitude, this.Planet);
        }
    }
}
