using System;
using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    public class Cow:Animal
    {
        private const int CowHealth = 15;
        private const int CowProductionQuantity = 6;
        private const int CowHealthEffect = 4;
       
        public Cow(string id) 
            : base(id, CowHealth, CowProductionQuantity)
        {
            this.Type = ProductType.Milk;
        }

        public ProductType Type { get; private set; }

        public override void Eat(IEdible food, int quantity)
        {
            if (food.Quantity >= quantity)
            {
                food.Quantity -= quantity;

                if (food.FoodType == FoodType.Organic)
                {
                    this.Health += food.HealthEffect*quantity;
                }
                else
                {
                    this.Health -= food.HealthEffect*quantity;
                }
            }
            else
            {
                throw new ArgumentException("Not enought food!");
            }
           
        }

        public override Product GetProduct()
        {
            if (IsAlive)
            {
                this.Health -= 2;
                return new Food(this.Id + "Product", this.Type, FoodType.Organic, this.ProductionQuantity,
                    CowHealthEffect);
            }
            else
            {
                throw new ArgumentException("Cow is not alive!");
            }
        }
    }
}


