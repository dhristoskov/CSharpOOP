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
            if (ship.Health - base.Damage < 0)
            {
                ship.Health = 0;
            }
            else
            {
            ship.Health -= base.Damage;

            }
            if (ship.Shields - base.Damage*2 < 0)
            {
                ship.Shields = 0;
            }
            else
            {
                ship.Shields -= base.Damage*2;
            }
        }
    }
}
