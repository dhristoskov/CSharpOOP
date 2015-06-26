using System;
using System.Text;
using Cosmetics.Common;

namespace Cosmetics.Products
{
    public class Shampoo : Products.Product, Contracts.IShampoo
    {
        private uint _milliliters;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public uint Milliliters
        {
            get { return this._milliliters; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Milliliters can not be negative number!");
                }
                this._milliliters = value;
            }
        }

        public override decimal Price
        {
            get { return base.Price*this.Milliliters; }
        }

        public UsageType Usage { get; private set; }

        public override string Print()
        {
            StringBuilder shampoo = new StringBuilder(base.Print());
            shampoo.AppendFormat("  * Quantity: {0} ml", this.Milliliters)
                .AppendLine()
                .AppendFormat("  * Usage: {0}", this.Usage);

            return shampoo.ToString();
        }
    }
}
 