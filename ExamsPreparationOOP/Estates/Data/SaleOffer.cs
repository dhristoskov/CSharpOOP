using System;
using Estates.Interfaces;

namespace Estates.Data
{
    public class SaleOffer:Offer,ISaleOffer
    {
        private decimal _price;
        public SaleOffer()
        {
            base.Type = OfferType.Sale;
        }

        public decimal Price
        {
            get { return this._price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price","Price can not be negative number!");
                }
                this._price = value;
            }
        }

        public override string ToString()
        {
            return base.ToString()+ string.Format(", Price = {0}",this.Price);
        }
    }
}