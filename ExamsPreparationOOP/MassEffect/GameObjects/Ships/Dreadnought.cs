

namespace MassEffect.GameObjects.Ships
{
    using System;
    using Locations;
    using Projectiles;
    using Interfaces;

    public class Dreadnought : StarShip
    {
        public Dreadnought(string name, StarSystem location) 
            : base(name, 200, 300, 150, 700, location)
        {
            this.ShipType = StarshipType.Dreadnought;
        }

        public override IProjectile ProduceAttack()
        {
            int dreadnoughtDamage = this.Damage + this.Shields / 2;
            return new Laser(dreadnoughtDamage);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;
            attack.Hit(this);
            if (this.Shields - 50 < 0)
            {
                this.Shields = 0;
                return;
            }
            this.Shields -= 50;
        }

        public override string ToString()
        {
            if (this.Health > 0)
            {
                return base.ToString();
            }
            else
            {
                return string.Format("--{0} - {1}", this.Name, this.ShipType) + Environment.NewLine + "(Destroyed)";
            }
        }
    }
}
