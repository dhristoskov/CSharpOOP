using System;
using Estates.Interfaces;

namespace Estates.Data
{
    public class RentOffer : Offer, IRentOffer
    {
        private decimal _pricePerMonth;

        public RentOffer()
        {
            base.Type = OfferType.Rent;
        }

        public decimal PricePerMonth
        {
            get { return this._pricePerMonth; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price Per Month", "Price per month can not be negative number!");
                }
                this._pricePerMonth = value;
            }
        }

        public override string ToString()
        {
            return base.ToString()+ string.Format(", Price = {0}", this.PricePerMonth);
        }
    }
}