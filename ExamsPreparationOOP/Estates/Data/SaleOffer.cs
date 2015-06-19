using Estates.Interfaces;

namespace Estates.Data
{
    public class SaleOffer : Offer, Interfaces.ISaleOffer
    {      
        public SaleOffer()
        {
            this.Type = OfferType.Sale;
        }

        public decimal Price
        {
            get { return this.GlobalPrice; }
            set { this.GlobalPrice = value; }
        }

    }
}