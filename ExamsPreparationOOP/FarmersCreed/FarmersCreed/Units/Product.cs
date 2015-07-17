using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    using System;
    using System.Collections.Generic;

    public class Product : GameObject, IProduct
    {
        private int _quantity;
        private ProductType _productType;

        public Product(string id, ProductType productType, int quantity)
            : base(id)
        {
            this.Quantity = quantity;
            this.ProductType = productType;
        }

        public int Quantity
        {
            get { return this._quantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Product quantity cannot be negative!");
                }
                this._quantity = value;
            }
        }

        public ProductType ProductType
        {
            get { return this._productType; }
            set { this._productType = value; }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Quantity: {0}, Product Type: {1}", this.Quantity, this.ProductType);
        }
    }
}
