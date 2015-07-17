namespace FarmersCreed.Units
{
    using System;

    public abstract class Plant : FarmUnit
    {
        private int _growTime;

        protected Plant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity)
        {
            this.GrowTime = growTime;
            this.HasGrown = false;
        }
                          
        public int GrowTime
        {
            get { return this._growTime; }
            set {              
                this._growTime = value;
                if (_growTime <= 0)
                {
                    this.HasGrown = true;
                }
            }
        }

        public bool HasGrown { get; set; }

        public virtual void Water()
        {
            base.Health += 2;
        }

        public virtual void Wither()
        {
            base.Health -= 1;
        }

        public virtual void Grow()
        {
            this.GrowTime -= 1;
        }

        public override string ToString()
        {
            if (IsAlive)
            {
                return base.ToString() + string.Format(", Grown: {0}", this.HasGrown ? "Yes" : "No");
            }
            else
            {
                return base.ToString();
            }
            
        }
    }
}