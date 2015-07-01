using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Projectiles
{
    public class ShieldReaver : GameObjects.Projectiles.Projectile
    {
        public ShieldReaver(int damage) 
            : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            ship.Health -= base.Damage;
            ship.Shields -= base.Damage*2;
        }
    }
}