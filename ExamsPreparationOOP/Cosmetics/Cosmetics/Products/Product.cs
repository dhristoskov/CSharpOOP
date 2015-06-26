using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Cosmetics.Common;

namespace Cosmetics.Products
{
    public abstract class Product : Contracts.IProduct
    {
        private string _name;
        private string _brand;
        private decimal _price;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }


        public string Name
        {
            get { return this._name; }
            private set
            {
                if (value.Length < 3 || value.Length > 10)
                {
                    throw new ArgumentException(String.Format("Product name must be between {0} and {1} symbols long!", 3, 10));
                }
                else if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(Name,"Product name can not be null or empty!");
                }
                this._name = value;
            }
        }

        public string Brand
        {
            get { return this._brand; }
            private set
            {
                if (value.Length < 2 || value.Length > 10)
                {
                    throw new ArgumentException (String.Format("Product brand must be between {0} and {1} symbols long!", 2, 10));
                }
                else if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(Brand,"Product brand can not be null or empty!");
                }
                this._brand = value;
            }
        }

        public virtual decimal Price
        {
            get { return this._price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The price can not be negatice number!");
                }
                this._price = value;
            }
        }

        public GenderType Gender { get; private set; }

        public virtual string Print()
        {
           StringBuilder product = new StringBuilder();          
            product.AppendFormat("- {0} - {1}:", this.Brand, this.Name)
                .AppendLine()
                .AppendFormat("  * Price: ${0}", this.Price)
                .AppendLine()
                .AppendFormat("  * For gender: {0}", this.Gender).AppendLine();

            return product.ToString();
        }
    }
}
