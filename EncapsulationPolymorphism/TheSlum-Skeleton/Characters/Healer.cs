using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheSlum
{
    public class Healer : Character, TheSlum.Interfaces.IHeal
    {
        public int HealingPoints { get; set; }

        public Healer(string id, int x, int y, Team team,int healingPoints = 60)
            : base(id, x, y, 75, 50, team, 6)
        {
            this.HealingPoints = healingPoints;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var myTarget = targetsList.OrderBy(targetHP => targetHP.HealthPoints).
                FirstOrDefault(target => target.IsAlive && target.Team == this.Team && target != this);
            return myTarget;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            base.ApplyItemEffects(item); ;
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            base.RemoveItemEffects(item);
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(", Healing: {0}", this.HealingPoints);
        }
    }
}
