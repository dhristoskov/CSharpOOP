using System;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(string model, MaterialType type, decimal price, decimal height, int numberOfLegs)
            : base(model, type, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            if (height > 0)
            {
                this.Height = height;
            }
        }       
    }
}