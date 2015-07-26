using System.Collections.Generic;
using NightlifeEntertainment.Enums;

namespace NightlifeEntertainment.Venues
{
    public class Cinema : Venue
    {
        public Cinema(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Movie, PerformanceType.Concert })
        {
        }
    }
}
