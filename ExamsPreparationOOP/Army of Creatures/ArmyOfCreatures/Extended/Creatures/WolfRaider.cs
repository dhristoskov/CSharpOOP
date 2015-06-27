using ArmyOfCreatures.Extended.Specialties;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class WolfRaider : Logic.Creatures.Creature
    {
        private const int DefaultWolfRaiderAttack = 8;
        private const int DefaultWolfRaiderDefense = 5;
        private const int DefaultWolfRaiderHealth = 10;
        private const decimal DefaultWolfRaiderDamage = 3.5m;
        private const int WolfRaiderDoubleDamage = 7;

        public WolfRaider()
            : base(DefaultWolfRaiderAttack, DefaultWolfRaiderDefense, DefaultWolfRaiderHealth, DefaultWolfRaiderDamage)
        {
            this.AddSpecialty(new DoubleDamage(WolfRaiderDoubleDamage));
        }
    }
}