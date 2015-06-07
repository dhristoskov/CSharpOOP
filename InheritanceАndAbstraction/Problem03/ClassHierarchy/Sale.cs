using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem03
{
    internal class Sale : ISale
    {
        private string productName;
        private DateTime date;
        private decimal price;

        public Sale(string productName, DateTime date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                this.productName = value;
            }
        }

        public DateTime Date
        {
            get { return this.date; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.date = value;
            }
        }
        public decimal Price 
        {
            get { return this.price; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.price = value;
            }
        }
        public override string ToString()
        {
            return String.Format(" Prod.Name:{0},Date:{1},Price:{2:0.00}", this.ProductName, this.Date, this.Price);
        }
    }
}
