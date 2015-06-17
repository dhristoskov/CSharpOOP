using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infestation.Supplements;

namespace Infestation
{
    public class Marine : Human
    {
        public Marine(string id) : base(id)
        {
            base.AddSupplement(new WeaponrySkill());
        }
      
        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            var marineTarget = attackableUnits.OrderByDescending(s => s.Health).FirstOrDefault(s => s.Power <= this.Aggression);
            var optimalAttackableUnit = marineTarget;
            return optimalAttackableUnit;
        }
    }
}