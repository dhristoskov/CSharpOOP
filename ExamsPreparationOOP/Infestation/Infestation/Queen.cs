using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Queen : Unit
    {
        public Queen(string id)
            : base(id, UnitClassification.Psionic, 30, 1, 1)
        {
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            bool attackUnit = this.Id != unit.Id && 
            InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification) == this.UnitClassification;
            return attackUnit;
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.CanAttackUnit(unit));
            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);
            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }
            return Interaction.PassiveInteraction;
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            var target = attackableUnits.OrderBy(s => s.Health).FirstOrDefault();
            var optimalAttackableUnit = target;
            return optimalAttackableUnit;
        }
    }
}