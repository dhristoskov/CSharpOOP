namespace MassEffect.GameObjects.Ships
{
    using System;
    using Locations;
    using Interfaces;
    using Projectiles;

    public class Frigate : StarShip
    {
        private int _projectiles;

        public Frigate(string name, StarSystem location)
            : base(name, 60, 50, 30, 220, location)
        {
            base.ShipType = StarshipType.Frigate;
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
                return base.ToString() + Environment.NewLine +
                       string.Format("-Projectiles fired: {0}", _projectiles);
            }
            else
            {
                return string.Format("--{0} - {1}", this.Name, this.ShipType) + Environment.NewLine + "(Destroyed)";
            }
        }
    }
}
