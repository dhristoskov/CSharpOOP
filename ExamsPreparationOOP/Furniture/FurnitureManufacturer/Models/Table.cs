using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    internal class Table : Furniture, ITable
    {
        private decimal _length;
        private decimal _width;

        public Table(string model, MaterialType material, decimal price, decimal height, decimal length, decimal width)
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        #region Properies

        public decimal Area => this.Length*this.Width;

        public decimal Length
        {
            get { return this._length; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this._length = value;
            }
        }

        public decimal Width
        {
            get { return this._width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this._width = value;
            }
        }

        public override string ToString()
        {

            return
                String.Format(
                    "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}",
                    this.GetType().Name, base.Model, base.Material, base.Price, base.Height, this.Length, this.Width,
                    this.Area);
        }

        #endregion
    }
}
