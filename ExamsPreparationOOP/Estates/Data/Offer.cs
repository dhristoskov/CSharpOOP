using System;
using Estates.Interfaces;

namespace Estates.Data
{
    public abstract class Offer:IOffer
    {     
        protected decimal GlobalPrice { get; set; }  
        public OfferType Type { get; set; }
        public IEstate Estate { get; set; }

        public override string ToString()
        {
            return String.Format("{0}: Estate = {1}, Location = {2}, Price = {3}", this.Type, this.Estate.Name,
                this.Estate.Location,this.GlobalPrice);
        }
    }
}