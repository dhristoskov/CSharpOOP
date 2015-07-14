using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

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
            var optimalAttackableUnit =
                attackableUnits.OrderByDescending(unit => unit.Health)
                    .FirstOrDefault(unit => unit.Power <= this.Aggression);
            return optimalAttackableUnit;
        }
    }
}