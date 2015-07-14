using System;
using Estates.Interfaces;

namespace Estates.Data
{
    public abstract class Estate : IEstate
    {
        private const double AreaMaxRange = 10000;
        private string _name;
        private double _area;
        private string _location;

        public string Name
        {
            get { return this._name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name","Name can not be null or empty!");
                }
                this._name = value;
            }
        }

        public double Area
        {
            get { return this._area; }
            set
            {
                if (value > AreaMaxRange || value < 0)
                {
                    throw new ArgumentOutOfRangeException("Area", "Area can not be greater than 10000 or less than 0!");
                }
                this._area = value;
            }
        }

        public string Location
        {
            get { return this._location; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Location", "Name can not be null or empty!");
                }
                this._location = value;
            }
        }
        public bool IsFurnished { get; set; }
        public EstateType Type { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}", this.Type, this.Name,
                this.Area, this.Location, this.IsFurnished ? "Yes" : "No");
        }
    }
}
