using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MassEffect.GameObjects.Enhancements;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;

namespace MassEffect.GameObjects.Ships
{
    public abstract class StarShip : IStarship
    {
        private string _name;
        private int _health;
        private int _shields;
        private int _damage;
        private double _fuel;
        private readonly IList<Enhancement> _enhancements;

        protected StarShip(string name, int health, int shileds, int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shileds;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
            this._enhancements = new List<Enhancement>();
        }

        #region Properties

        public string Name
        {
            get { return this._name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name", "Ship name can not be null or empty!");
                }
                this._name = value;
            }
        }

        public int Health
        {
            get { return this._health; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Health", "Ship health can not be zero or negative number!");
                }
                this._health = value;
            }
        }

        public int Shields
        {
            get { return this._shields; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Shields", "Ship shield can not be zero or negative number!");
                }
                this._shields = value;
            }
        }

        public int Damage
        {
            get { return this._damage; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Damage", "Ship damage can not be zero or negative number!");
                }
                this._damage = value;
            }
        }

        public double Fuel
        {
            get { return this._fuel; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Fuel", "Ship fuel can not be zero or negative number!");
                }
                this._fuel = value;
            }
        }

        public IEnumerable<Enhancement> Enhancements
        {
            get { return this._enhancements; }
        }

        public StarSystem Location { get; set; }

        #endregion

        public void AddEnhancement(Enhancement enhancement)
        {
            this._enhancements.Add(enhancement);
            this.Shields += enhancement.ShieldBonus;
            this.Damage += enhancement.DamageBonus;
            this.Fuel += enhancement.FuelBonus;
        }

        public abstract IProjectile ProduceAttack();

        public virtual void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);
        }

        public override string ToString()
        {
            StringBuilder starShip = new StringBuilder();

            starShip.AppendLine(string.Format("-Location: {0}", this.Location.Name))
                .AppendLine(string.Format("-Health: {0}", this.Health))
                .AppendLine(string.Format("-Shields: {0}", this.Shields))
                .AppendLine(string.Format("-Damage: {0}", this.Damage))
                .AppendLine(string.Format("-Fuel: {0}", this.Fuel))
                .Append(string.Format("-Enhancements: {0}", !Enhancements.Any() ? "N/A" : ""))
                .Append(String.Join(", ", this.Enhancements));

            return starShip.ToString();
        }
    }
}


