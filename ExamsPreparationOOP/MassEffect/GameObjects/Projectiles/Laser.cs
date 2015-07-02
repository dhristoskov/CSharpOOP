using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Projectiles
{
    public class Laser : Projectile
    {
        public Laser(int damage) : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            if (base.Damage <= ship.Shields)
            {
                ship.Shields -= base.Damage;
            }
            else
            {
                int totalDamage = base.Damage;
                totalDamage -= ship.Shields;
                if (ship.Health - totalDamage < 0)
                {
                    ship.Health = 0;
                }
                else
                {
                    ship.Health -= totalDamage;
                }
                ship.Shields = 0;
            }
        }
    }
}
