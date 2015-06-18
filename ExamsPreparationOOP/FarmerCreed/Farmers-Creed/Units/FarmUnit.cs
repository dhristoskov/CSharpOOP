using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    using System;

    public abstract class FarmUnit : GameObject, IProductProduceable
    {
        private int _health;
        private int _productionQuantity;
        private bool _isAlive = true;

        protected FarmUnit(string id, int health, int productionQuantity)
            : base(id)
        {
            this.Health = health;
            this.ProductionQuantity = productionQuantity;
        }

        public int Health
        {
            get {return this._health;}
            set
            {
                this._health = value;
                if (this._health <= 0)
                {
                    this._isAlive = false;
                }
            }
        }
        public bool IsAlive
        {
            get { return this._isAlive; } 
            set { this._isAlive = value; }
        }

        public int ProductionQuantity
        {
            get { return this._productionQuantity; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this._productionQuantity = value;
            }
        }

        public override string ToString()
        {
            if (IsAlive)
            {
                return base.ToString() + String.Format(", Health: {0}", this.Health);
            }
            else
            {
                return base.ToString() + ", DEAD";
            }
        }

        public abstract Product GetProduct();
    }
}
