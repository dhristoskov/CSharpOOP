using System.Collections.Generic;
using NightlifeEntertainment.Enums;

namespace NightlifeEntertainment.Venues
{
    public class SportsHall : Venue
    {
        public SportsHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> {PerformanceType.Sport, PerformanceType.Concert})
        {
        }
    }
}