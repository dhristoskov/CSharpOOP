using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Queen : Unit
    {
        private const int QueenHealth = 30;
        private const int QueenPower = 1;
        private const int QueenAggression = 1;

        public Queen(string id) 
            : base(id, UnitClassification.Psionic, QueenHealth, QueenPower, QueenAggression)
        {
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            if (this.Id != unit.Id)
            {
                if (InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification) ==
                    this.UnitClassification)
                {
                    return true;
                }
            }
            return false;
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            var optimalAttackableUnit = attackableUnits.OrderBy(unit => unit.Health).FirstOrDefault();
            return optimalAttackableUnit;
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
    }
}