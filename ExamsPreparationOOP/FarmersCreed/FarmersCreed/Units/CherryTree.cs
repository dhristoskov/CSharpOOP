using System;

namespace FarmersCreed.Units
{
    public class CherryTree : FoodPlant
    {
        private const int CherryTreeHealth = 14;
        private const int CherryTreeGrowTime = 3;
        private const int CherryTreeProductionQuantity = 4;
        private const int CherryTreeHealthEffect = 2;

        public CherryTree(string id)
            : base(id, CherryTreeHealth, CherryTreeProductionQuantity, CherryTreeGrowTime)
        {
            this.Type = ProductType.Cherry;
        }

        public ProductType Type { get; private set; }

        public override Product GetProduct()
        {
            if (IsAlive)
            {
                return new Food(this.Id + "Product", this.Type, FoodType.Organic, this.ProductionQuantity,
                    CherryTreeHealthEffect);
            }
            else
            {
                throw new ArgumentException("Cherry Tree is not alive!");
            }
        }
    }
}


