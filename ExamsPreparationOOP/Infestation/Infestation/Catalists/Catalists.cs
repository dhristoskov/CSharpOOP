using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public abstract class Catalists:ISupplement
    {
        private int _powerEffect;
        private int _healthEffect;
        private int _aggressionEffect;

        protected Catalists(int powerEffect,int healthEffect, int aggressionEffect)
        {
            this.PowerEffect = powerEffect;
            this.HealthEffect = healthEffect;
            this.AggressionEffect = aggressionEffect;
        }
        public virtual void ReactTo(ISupplement otherSupplement)
        {           
        }

        public int PowerEffect
        {
            get { return this._powerEffect; }
            protected set { this._powerEffect = value; }
        }

        public int HealthEffect {
            get { return this._healthEffect; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Health Effect", "Health Effect can not be negative number!");
                }
                this._healthEffect = value;
            }
        }
        public int AggressionEffect {
            get { return this._aggressionEffect; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Aggression Effect", "Aggression Effect can not be negative number!");
                }
                this._aggressionEffect = value;
            }
        }
    }
}