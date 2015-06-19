using Estates.Interfaces;

namespace Estates.Data
{
    public class RentOffer : Offer, Interfaces.IRentOffer
    {       
        public RentOffer()
        {
            this.Type = OfferType.Rent;
        }

        public decimal PricePerMonth
        {
            get { return this.GlobalPrice; }
            set { this.GlobalPrice = value; }
        }
    }
}