using System.Collections.Generic;
using NightlifeEntertainment.Enums;

namespace NightlifeEntertainment.Venues
{
    public class ConcertHall : Venue
    {
        public ConcertHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> {PerformanceType.Concert, PerformanceType.Opera, PerformanceType.Theatre})
        {
        }
    }
}