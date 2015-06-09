using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheSlum
{
    public class Warrior : Character, TheSlum.Interfaces.IAttack
    {
        public int AttackPoints { get; set; }

        public Warrior(string id, int x, int y, Team team, int attackPoints = 150)
            : base(id, x, y, 200, 100, team, 2)
        {
            this.AttackPoints = attackPoints;
        }
        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var myTarget = targetsList.FirstOrDefault(target => (target.Team != this.Team && target.IsAlive));
            return myTarget;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item); ;
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }

        protected override void ApplyItemEffects(Item item)
        {
            this.AttackPoints += item.AttackEffect;
            base.ApplyItemEffects(item);
        }

        protected override void RemoveItemEffects(Item item)
        {
            this.AttackPoints -= item.AttackEffect;
            base.RemoveItemEffects(item);
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(", Attack: {0}", this.AttackPoints);
        }
    }
}
