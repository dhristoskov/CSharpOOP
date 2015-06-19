using System;
using System.Security.Authentication.ExtendedProtection.Configuration;
using Estates.Interfaces;

namespace Estates.Data
{
    public abstract class Estate : IEstate
    {
        private string _name;        
        private double _area;
        private string _location;
        public bool IsFurnished { get; set; }
        public EstateType Type { get; set; }
     
        public string Name
        {
            get { return this._name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                this._name = value;
            }
        }

        public double Area
        {
            get { return this._area; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this._area = value;
            }
        }
        public string Location {
            get { return this._location; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                this._location = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{4}: Name = {0}, Area = {1}, Location = {2}, Furnished = {3}", this.Name, this.Area,
                this.Location, this.IsFurnished ? "Yes" : "No", this.Type);
        }
    }
}