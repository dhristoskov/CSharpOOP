using Estates.Engine;
using Estates.Interfaces;
using System;
using System.CodeDom;

namespace Estates.Data
{
    public class EstateFactory
    {
        public static IEstateEngine CreateEstateEngine()
        {
            return new ExtendedEstateEngine();
        }

        public static IEstate CreateEstate(EstateType type)
        {
            switch (type)
            {
                case EstateType.Garage:
                    return new Garage();
                case EstateType.Apartment:
                    return new Apartment();
                case EstateType.House:
                    return new House();
                case EstateType.Office:
                    return new Office();
                default:
                    throw new ArgumentException("This type Estate does not exist!");
            }
        }

        public static IOffer CreateOffer(OfferType type)
        {
            switch (type)
            {
                case OfferType.Rent:
                    return new RentOffer();
                case OfferType.Sale:
                    return new SaleOffer();
                default:
                    throw new ArgumentException("This type Offer does not exist!");
            }
        }
    }
}
