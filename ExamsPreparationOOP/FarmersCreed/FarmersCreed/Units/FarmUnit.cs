using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    using System;

    public abstract class FarmUnit : GameObject, IProductProduceable
    {
        private int _health;
        private int _productionQuantity;

        protected FarmUnit(string id, int health, int productionQuantity)
            : base(id)
        {
            this.Health = health;
            this.ProductionQuantity = productionQuantity;
            this.IsAlive = true;
        }

        public int Health
        {
            get { return this._health; }
            set {               
                this._health = value;
                if (this._health <= 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public int ProductionQuantity
        {
            get { return this._productionQuantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Production","Production quantity can not be negative number!");
                }
                this._productionQuantity = value;
            }
        }

        public bool IsAlive { get; set; }

        public abstract Product GetProduct();

        public override string ToString()
        {
            if (IsAlive)
            {
                return base.ToString() + string.Format(", Health: {0}", this.Health);
            }
            else
            {
                return base.ToString() + ", DEAD";
            }           
        }
    }
}
