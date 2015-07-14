using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Parasite : Unit
    {
        private const int ParasiteHealth = 1;
        private const int ParasitePower = 1;
        private const int ParasiteAggression = 1;

        public Parasite(string id) 
            : base(id, UnitClassification.Biological, ParasiteHealth, ParasitePower, ParasiteAggression)
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