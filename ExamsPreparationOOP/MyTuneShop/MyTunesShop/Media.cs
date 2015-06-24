using System;

namespace MyTunesShop
{
    public abstract class Media : IMedia
    {
        protected static readonly int MinYear = DateTime.MinValue.Year;
        protected static readonly int MaxYear = DateTime.Now.Year;

        protected string title;
        protected decimal price;

        protected Media(string title, decimal price)
        {
            this.Title = title;
            this.Price = price;
        }

        public string Title
        {
            get { return this.title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format("The media {0} can not be empty", this.Title));
                }
                this.title = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format("The media {0} can not be negative", this.Price));
                }
                this.price = value;
            }
        }
    }
}
