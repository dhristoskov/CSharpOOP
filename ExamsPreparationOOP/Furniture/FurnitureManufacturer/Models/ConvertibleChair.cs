using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    internal class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedHeight = 0.10m;
        private readonly decimal _heightState;
        public bool IsConverted { get;private set; }

        public ConvertibleChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.IsConverted = false;
            this._heightState = height;
        }

        public void Convert()
        {
            if (IsConverted == true)
            {
                this.IsConverted = false;
                base.Height = _heightState;
            }
            else if (IsConverted == false)
            {
                this.IsConverted = true;
                this.Height = ConvertedHeight;
            }
        }

        public override string ToString()
        {
            return String.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}",
                this.GetType().Name, base.Model, base.Material, base.Price, base.Height, base.NumberOfLegs,
                this.IsConverted ? "Converted" : "Normal");
        }
    }
}
