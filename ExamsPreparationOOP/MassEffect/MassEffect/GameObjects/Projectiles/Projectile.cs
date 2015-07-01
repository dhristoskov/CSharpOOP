using System;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Projectiles
{
    public abstract class Projectile : Interfaces.IProjectile
    {
        private int _damage;

        protected Projectile(int damage)
        {
            this.Damage = damage;
        }

        public int Damage
        {
            get { return this._damage; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Damage","Damage can not be negative or zero number!");
                }
                this._damage = value;
            }
        }

        public virtual void Hit(IStarship ship)
        {
        }
    }
}