namespace FarmersCreed.Units
{
    public abstract class FoodPlant : Plant
    {
        protected FoodPlant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity, growTime)
        {
        }

        public override void Water()
        {
            base.Health += 1;
        }

        public override void Wither()
        {
            base.Health -= 2;
        }
    }
}

