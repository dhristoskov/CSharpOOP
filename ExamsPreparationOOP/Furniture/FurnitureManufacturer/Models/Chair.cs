using System;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Chair : Furniture, IChair
    {
        private int _numberOfLegs;

        public Chair(string model, MaterialType type, decimal price, decimal height, int numberOfLegs)
            : base(model, type, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get { return this._numberOfLegs; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Chair", "Chair has to have at last one leg!");
                }
                this._numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(", Legs: {0}", this.NumberOfLegs);
        }
    }
}
