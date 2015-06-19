using Estates.Interfaces;

namespace Estates.Data
{
    public class Apartment : BuildingEstate, IApartment
    {
        public Apartment()
        {
            base.Type = EstateType.Apartment;
        }
    }
}