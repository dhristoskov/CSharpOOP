using System;
using System.Security.Principal;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public class Dreadnought : GameObjects.Ships.StarShip
    {
        public StarshipType Type { get;private set; }

        public Dreadnought(string name, StarSystem location) 
            : base(name, 200, 300, 150, 700, location)
        {
            this.Type = StarshipType.Dreadnought;
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
            this.Shields -= 50;
        }

        public override string ToString()
        {
            if (this.Health > 0)
            {
                return string.Format("--{0} - {1}", this.Name, this.Type)
                       + Environment.NewLine + base.ToString() + Environment.NewLine;
            }
            else
            {
                return string.Format("--{0} - {1}", this.Name, this.Type) + Environment.NewLine + "Destroyed";
            }
        }
    }
}