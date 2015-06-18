namespace FarmersCreed.Units
{
    using System;

    public abstract class Plant : FarmUnit
    {
        private bool _hasGrown = false;
        private int _growTime;

        protected Plant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity)
        {
            this.GrowTime = growTime;
        }

        public bool HasGrown
        {
            get { return this._hasGrown; }
        }

        public int GrowTime
        {
            get { return this._growTime; }
            set
            {
                this._growTime = value;
                if (_growTime <= 0)
                {
                    this._hasGrown = true;
                }
            }
        }

        public virtual void Water()
        {
            base.Health += 2;
        }

        public virtual void Wither()
        {
            base.Health--;
        }

        public virtual void Grow()
        {
            this.GrowTime--;
        }

        public override string ToString()
        {
            if (IsAlive)
            {
                return base.ToString() + String.Format(", Grown: {0}", this.HasGrown ? "Yes" : "No");
            }
            else
            {
                return base.ToString();
            }
            
        }

        public abstract override Product GetProduct();
    }
}
