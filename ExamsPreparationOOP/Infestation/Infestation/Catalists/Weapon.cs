using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Weapon : Catalists
    {

        private const int CatalistPowerEffect = 10;
        private const int CatalistHealthEffect = 0;
        private const int CatalistAggressionEffect = 3;

        public Weapon() 
            : base(CatalistPowerEffect, CatalistHealthEffect, CatalistAggressionEffect)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                base.PowerEffect = CatalistPowerEffect;
                base.AggressionEffect = CatalistAggressionEffect;
            }
        }
    }
}