using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class WeaponrySkill : Catalists
    {
        private const int WeaponrySkillPowerEffect = 0;
        private const int WeaponrySkillHealthEffect = 0;
        private const int WeaponrySkillAggressionEffect = 0;

        public WeaponrySkill() 
            : base(WeaponrySkillPowerEffect, WeaponrySkillHealthEffect, WeaponrySkillAggressionEffect)
        {
        }
    }
}