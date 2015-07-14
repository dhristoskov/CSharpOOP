using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class PowerCatalyst : Catalists
    {
        private const int CatalistPowerEffect = 3;
        private const int CatalistHealthEffect = 0;
        private const int CatalistAggressionEffect = 0;

        public PowerCatalyst()
            : base(CatalistPowerEffect, CatalistHealthEffect, CatalistAggressionEffect)
        {
        }
    }
}