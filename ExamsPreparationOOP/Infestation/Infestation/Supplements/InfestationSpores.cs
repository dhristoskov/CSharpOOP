namespace Infestation.Supplements
{
    public class InfestationSpores : Supplement
    {
        public InfestationSpores()
            : base(20, 0, -1)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                AggressionEffect = 0;
                PowerEffect = 0;
                HealthEffect = 0;
            }
        }
    }
}