using System;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public class Cruiser : GameObjects.Ships.StarShip
    {
        public Cruiser(string name, StarSystem location) 
            : base(name, 100, 100, 50, 300, location)
        {
            this.ShipType = StarshipType.Cruiser;
        }

        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
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
