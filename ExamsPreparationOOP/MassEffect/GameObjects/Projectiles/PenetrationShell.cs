using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Projectiles
{
    public class PenetrationShell : GameObjects.Projectiles.Projectile
    {
        public PenetrationShell(int damage) 
            : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            if (ship.Health- base.Damage < 0)
            {
                ship.Health = 0;
            }
            else
            {
                ship.Health -= base.Damage;
            }
        }
    }
}
