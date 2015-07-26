using System.Collections.Generic;
using NightlifeEntertainment.Enums;

namespace NightlifeEntertainment.Interfaces
{
    public interface IVenue
    {
        string Name { get; }

        string Location { get; }

        int Seats { get; }

        IList<PerformanceType> AllowedTypes { get; }
    }
}
