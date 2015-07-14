using System;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedHeight = .10m;
        private readonly decimal _heightState;

        public ConvertibleChair(string model, MaterialType type, decimal price, decimal height, int numberOfLegs)
            : base(model, type, price, height, numberOfLegs)
        {
            this.IsConverted = false;
            this._heightState = height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            if (IsConverted)
            {
                this.Height = _heightState;
                this.IsConverted = false;
            }
            else
            {
                this.Height = ConvertedHeight;
                this.IsConverted = true;
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                   String.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal");
        }
    }
}