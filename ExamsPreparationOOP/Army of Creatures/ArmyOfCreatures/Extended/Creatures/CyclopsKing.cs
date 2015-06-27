using System.Configuration;
using ArmyOfCreatures.Extended.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class CyclopsKing : Logic.Creatures.Creature
    {
        private const int DefaultCyclopsKingAttack = 17;
        private const int DefaultCyclopsKingDefense = 13;
        private const int DefaultCyclopsKingHealth = 70;
        private const decimal DefaultCyclopsKingDamage = 18;
        private const int CyclopsKingAddAttackWhenSkip = 3;
        private const int CyclopsKinfDoubleAttackWhenAttacking = 4;
        private const int CyclopsKingDoubleDamage = 1;

        public CyclopsKing()
            : base(DefaultCyclopsKingAttack, DefaultCyclopsKingDefense, DefaultCyclopsKingHealth, DefaultCyclopsKingDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(CyclopsKingAddAttackWhenSkip));
            this.AddSpecialty(new DoubleAttackWhenAttacking(CyclopsKinfDoubleAttackWhenAttacking));
            this.AddSpecialty(new DoubleDamage(CyclopsKingDoubleDamage));
        }
    }
}