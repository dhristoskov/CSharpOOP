using System;
using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    public class Swine:Animal
    {
        private const int SwineHealth = 20;
        private const int SwineProductionQuantity = 1;
        private const int SwineHealthEffect = 5;
        
        public Swine(string id)
            : base(id, SwineHealth, SwineProductionQuantity)
        {
            this.Type = ProductType.PorkMeat;
        }

        public ProductType Type { get; private set; }

        public override void Eat(IEdible food, int quantity)
        {
            if (food.Quantity >= quantity)
            {
                food.Quantity -= quantity;
                this.Health += food.HealthEffect*quantity*2;
            }
            else
            {
                throw new ArgumentException("Not enought food!");
            }
        }

        public override void Starve()
        {
            this.Health -= 3;
        }

        public override Product GetProduct()
        {
            if (IsAlive)
            {               
                this.IsAlive = false;
                return new Food(this.Id + "Product", this.Type, FoodType.Meat, this.ProductionQuantity, SwineHealthEffect);
            }
            else
            {
                throw new ArgumentException("Swine is not alive!");
            }
        }
    }
}
