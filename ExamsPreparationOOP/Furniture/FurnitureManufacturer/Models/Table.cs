using System;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Table : Furniture, ITable
    {
        private decimal _length;
        private decimal _width;

        public Table(string model, MaterialType type, decimal price, decimal height, decimal length, decimal width)
            : base(model, type, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get { return this._length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Length", "Length can not be zero or negative number!");
                }
                this._length = value;
            }
        }

        public decimal Width
        {
            get { return this._width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width", "Width can not be zero or negative number!");
                }
                this._width = value;
            }
        }

        public decimal Area
        {
            get { return this.Length*this.Width; }
        }

        public override string ToString()
        {
            return base.ToString() +
                   String.Format(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area);

        }
    }
}