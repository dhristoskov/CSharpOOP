using System;
using Estates.Interfaces;

namespace Estates.Data
{
    public class Garage : Data.Estate, Interfaces.IGarage
    {
        private int _width;
        private int _height;

        public Garage()
        {
            this.Type = EstateType.Garage;
        }
        public int Width
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

        public int Height
        {
            get { return this._height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this._height = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(", Width: {0}, Height: {1}", this.Width, this.Height);
        }
    }
}