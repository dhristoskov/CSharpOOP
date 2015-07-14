using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class InfestationSpores : Catalists
    {
        private const int InfestationPowerEffect = -1;
        private const int InfestationHealthEffect = 0;
        private const int InfestationAggressionEffect = 20;

        public InfestationSpores() 
            : base(InfestationPowerEffect, InfestationHealthEffect, InfestationAggressionEffect)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                base.PowerEffect = 0;
                base.HealthEffect = 0;
                base.AggressionEffect = 0;
            }
        }
    }
}