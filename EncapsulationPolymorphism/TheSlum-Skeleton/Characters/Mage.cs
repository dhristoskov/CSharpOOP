using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheSlum
{
    public class Mage : Character, TheSlum.Interfaces.IAttack
    {
        public int AttackPoints { get; set; }

        public Mage(string id, int x, int y, Team team, int attackPoints = 300)
            : base(id, x, y, 150, 50, team, 5)
        {
            this.AttackPoints = attackPoints;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var myTarget = targetsList.LastOrDefault(target => (target.Team != this.Team && target.IsAlive));
            return myTarget;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item); 
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
