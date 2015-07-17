namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;

    public abstract class Animal : FarmUnit
    {
        protected Animal(string id, int health, int productionQuantity)
            : base(id, health, productionQuantity)
        {
        }

        public abstract void Eat(IEdible food, int quantity);

        public virtual void Starve()
        {
            this.Health -= 1;
        }
    }
}
