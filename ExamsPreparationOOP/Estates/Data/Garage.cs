using System;
using Estates.Interfaces;

namespace Estates.Data
{
    public class Garage : Estate, IGarage
    {
        private const int WidthMaxRange=500;
        private const int HeightMaxRange = 500;
        private int _width;
        private int _height;

        public Garage()
        {
            base.Type = EstateType.Garage;
        }


        public int Width
        {
            get { return this._width; }
            set
            {
                if (value > WidthMaxRange || value < 0)
                {
                    throw new ArgumentOutOfRangeException("Width","Width can not be greater than 500 or less than 0!");
                }
                this._width = value;
            }
        }

        public int Height
        {
            get { return this._height; }
            set
            {
                if (value > HeightMaxRange || value < 0)
                {
                    throw new ArgumentOutOfRangeException("Height", "Height can not be greater than 500 or less than 0!");
                }
                this._height = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Width: {0}, Height: {1}", this.Width, this.Height);
        }
    }
}