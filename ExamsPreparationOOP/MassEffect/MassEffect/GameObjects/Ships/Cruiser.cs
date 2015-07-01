using System;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public class Cruiser : GameObjects.Ships.StarShip
    {
        public StarshipType Type { get; private set; }
        public Cruiser(string name, StarSystem location) 
            : base(name, 100, 100, 50, 300, location)
        {
            this.Type = StarshipType.Cruiser;
        }

        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
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