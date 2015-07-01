using System;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Projectiles;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public class Frigate : GameObjects.Ships.StarShip
    {
        private int _projectiles;
        public StarshipType Type { get; private set; }

        public Frigate(string name, StarSystem location)
            : base(name, 60, 50, 30, 220, location)
        {
            this.Type=StarshipType.Frigate;
        }

        public override IProjectile ProduceAttack()
        {
            _projectiles++;
            return new ShieldReaver(this.Damage);
        }

        public override string ToString()
        {
            if (this.Health > 0)
            {
                return string.Format("--{0} - {1}", this.Name, this.Type)
                       + Environment.NewLine + base.ToString() + Environment.NewLine +
                       string.Format("-Projectiles fired: {0}", _projectiles) + Environment.NewLine;
            }
            else
            {
                return string.Format("--{0} - {1}", this.Name, this.Type) + Environment.NewLine + "Destroyed";
            }
        }
    }
}