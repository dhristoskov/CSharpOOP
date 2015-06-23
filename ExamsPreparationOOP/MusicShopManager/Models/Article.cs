using System;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public abstract class Article : IArticle
    {

        protected string _make;
        protected string _model;
        protected decimal _price;

        protected Article(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
        }


        public string Make
        {
            get { return this._make; }
            private set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format("The article {0} can not be empty", Make));
                }
                this._make = value;
            } 
        }

        public string Model
        {
            get { return this._model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format("The article {0} can not be empty", Model));
                }
                this._model = value;
            }
        }

        public decimal Price
        {
            get { return this._price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format("The {0} must be positive number",Price));
                }
                this._price = value;
            }
        }

        public override string ToString()
        {
            return string.Format("= {0} {1} =", this.Make, this.Model) + Environment.NewLine +
                   string.Format("Price: ${0:f2}", this.Price) +Environment.NewLine;
        }
    }
}

