using System;
using System.Globalization;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class DoubleAttackWhenAttacking : Logic.Specialties.Specialty
    {
        private int _rounds;

        public DoubleAttackWhenAttacking(int rounds)
        {
            this.Rounds = rounds;
        }

        public int Rounds
        {
            get
            {
                return this._rounds;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("_round", "The number of rounds should be greater than 0");
                }
                this._rounds = value;
            }
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.Rounds <= 0)
            {
                return;
            }

            attackerWithSpecialty.CurrentAttack *= 2;
            this.Rounds--;
        }

        public override void ApplyWhenDefending(ICreaturesInBattle defenderWithSpecialty, ICreaturesInBattle attacker)
        {
        }

        public override void ApplyAfterDefending(ICreaturesInBattle defenderWithSpecialty)
        {
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.Rounds);
        }
    }
}