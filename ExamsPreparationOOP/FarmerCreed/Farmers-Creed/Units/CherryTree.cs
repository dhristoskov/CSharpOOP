using System;

namespace FarmersCreed.Units
{
    public class CherryTree : FoodPlant
    {
        public CherryTree(string id) 
            : base(id, 14, 4, 3)
        {
        }

        public override Product GetProduct()
        {
            if (IsAlive)
            {
                return new Food(this.Id + "Product", ProductType.Cherry, FoodType.Organic, 4, 2);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}

