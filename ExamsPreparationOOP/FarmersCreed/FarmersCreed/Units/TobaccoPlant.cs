using System;
using System.Dynamic;

namespace FarmersCreed.Units
{
    public class TobaccoPlant:Plant
    {
        private const int TobaccoHealth = 12;
        private const int TobaccoGrowTime = 4;
        private const int TobaccoProductionQuantity = 10;
        
        public TobaccoPlant(string id)
            : base(id, TobaccoHealth, TobaccoProductionQuantity, TobaccoGrowTime)
        {
            this.Type = ProductType.Tobacco;
        }

        public ProductType Type { get; private set; }

        public override void Grow()
        {
            this.GrowTime -= 2;
        }

        public override Product GetProduct()
        {
            if (IsAlive && HasGrown)
            {
                return new Product(this.Id + "Product", this.Type, this.ProductionQuantity);
            }
            else
            {
                throw new ApplicationException("Tobacco plant is not alive or it is not grown yet!");
            }
        }
    }
}
