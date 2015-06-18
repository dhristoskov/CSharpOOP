using System;
using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    public class Swine : Animal
    {
        public Swine(string id) 
            : base(id, 20, 1)
        {
        }

        public override void Starve()
        {
            base.Health -= 3;
        }

        public override void Eat(IEdible food, int quantity)
        {
            if (food.Quantity >= quantity)
            {
                food.Quantity -= quantity;
                base.Health += food.HealthEffect*quantity*2;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public override Product GetProduct()
        {
            if (IsAlive)
            {
                this.IsAlive = false;
                return new Food(this.Id + "Product", ProductType.PorkMeat, FoodType.Meat, 1, 5);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}

