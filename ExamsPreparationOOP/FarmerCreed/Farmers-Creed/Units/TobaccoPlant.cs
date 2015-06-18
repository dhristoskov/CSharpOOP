using System;

namespace FarmersCreed.Units
{
    public class TobaccoPlant : Plant
    {
        public TobaccoPlant(string id)
            : base(id, 12, 10, 4)
        {
        }

        public override void Grow()
        {
            base.GrowTime -= 2;
        }

        public override Product GetProduct()
        {
            if (IsAlive && HasGrown)
            {
                return new Product(this.Id + "Product", ProductType.Tobacco, 10);
            }
            else
            {               
                throw new ArgumentException();
            }
        }
    }
}

