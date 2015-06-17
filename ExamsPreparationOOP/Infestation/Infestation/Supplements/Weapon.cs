namespace Infestation.Supplements
{
    public class Weapon : Supplement
    {
        public Weapon()
            : base(3, 0, 10)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                base.PowerEffect = 10;
                base.AggressionEffect = 3;
            }
        }
    }
}