using Estates.Interfaces;

namespace Estates.Data
{
    public class Office : BuildingEstate,IOffice
    {
        public Office()
        {
            this.Type = EstateType.Office;
        }
    }
}