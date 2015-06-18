using System;
using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    public class Cow : Animal
    {
        public Cow(string id) 
            : base(id, 15, 6)
        {
        }

        public override void Starve()
        {
            base.Health--;
        }

        public override void Eat(IEdible food, int quantity)
        {
            if (food.Quantity >= quantity)
            {
                food.Quantity -= quantity;
                if (food.FoodType == FoodType.Organic)
                {
                    base.Health += food.HealthEffect*quantity;
                }
                else
                {
                    base.Health -= food.HealthEffect*quantity;
                }
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
                base.Health -= 2;
                return new Food(this.Id + "Product", ProductType.Milk, FoodType.Organic, 6, 4);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
