using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class AggressionCatalyst : Catalists
    {
        private const int CatalistPowerEffect = 0;
        private const int CatalistHealthEffect = 0;
        private const int CatalistAggressionEffect = 3;

        public AggressionCatalyst()
            : base(CatalistPowerEffect, CatalistHealthEffect, CatalistAggressionEffect)
        {
        }
    }
}