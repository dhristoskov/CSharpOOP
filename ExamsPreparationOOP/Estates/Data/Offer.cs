using System;
using Estates.Interfaces;

namespace Estates.Data
{
    public abstract class Offer : IOffer
    {
        public OfferType Type { get; set; }
        public IEstate Estate { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: Estate = {1}, Location = {2}", this.Type, this.Estate.Name, this.Estate.Location);
        }
    }
}