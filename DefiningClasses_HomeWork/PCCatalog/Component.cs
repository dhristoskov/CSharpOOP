using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCatalog
{
    class Component
    {
        private string name;
        private string details;
        private decimal price;

        public Component(string name,decimal price,string details)
        {
            this.Name = name;
            this.Price = price;
            this.Details = details;
        }
        public Component(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
            this.Details = "N/A";
        }

        #region Properties
        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Please enter correct name!");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public string Details
        {

            get { return this.details; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Please enter correct details!");
                }
                else
                {
                    this.details = value;
                }
            }
        }
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Please enter correct price!");
                }
                else
                {
                    this.price = value;
                }
            }
        }
        #endregion
    }
}
