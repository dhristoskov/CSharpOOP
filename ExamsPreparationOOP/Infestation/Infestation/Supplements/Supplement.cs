namespace Infestation.Supplements
{
    public class Supplement : ISupplement
    {
        public int AggressionEffect { get; set; }
        public int HealthEffect { get; set; }
        public int PowerEffect { get; set; }

        public Supplement(int aggressionEffect, int healthEffect, int powerEffect)
        {
            this.AggressionEffect = aggressionEffect;
            this.HealthEffect = healthEffect;
            this.PowerEffect = powerEffect;
        }

        public virtual void ReactTo(ISupplement otherSupplement)
        {           
        }
    }
}