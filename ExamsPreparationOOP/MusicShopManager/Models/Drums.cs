using System;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public class Drums : Instrument, IDrums
    {
        private int _height;
        private int _width;
        public Drums(string make, string model, decimal price, string color, int width, int height) : base(make, model, price, color)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get { return this._width; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The drums {0} should be positive.", Width));
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
                    throw new ArgumentOutOfRangeException(string.Format("The drums {0} should be positive.", Height));
                }
                this._height = value;
            }
        }

        public override string ToString()
        {
            return  base.ToString() + string.Format("Size: {0}cm x {1}cm", this.Width, this.Height) + Environment.NewLine;
        }
    }
}
