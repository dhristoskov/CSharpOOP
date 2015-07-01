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
            ship.Health -= base.Damage;
        }
    }
}