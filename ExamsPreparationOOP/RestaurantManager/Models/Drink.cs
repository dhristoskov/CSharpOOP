using System;

namespace RestaurantManager.Models
{
    public class Drink : Models.Recipe, Interfaces.IDrink
    {
        private const int MaxCalories = 100;
        private const int MaxPrepareTime = 20;

        public Drink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
            : base(name, price, calories, quantityPerServing, timeToPrepare, MetricUnit.Milliliters)
        {
            this.IsCarbonated = isCarbonated;
        }

        #region Properties

        public new int Calories
        {
            get { return base._calories; }
            protected set
            {
                if (value > MaxCalories || value < 0)
                {
                    throw new ArgumentException("The <parameter> must be positive");
                }
                this._calories = value;
            }
        }

        public new int TimeToPrepare
        {
            get { return base._timeToPrepare; }
            protected set
            {
                if (value > MaxPrepareTime || value < 0)
                {
                    throw new ArgumentException("The <parameter> must be positive");
                }
                this._timeToPrepare = value;
            }
        }

        public bool IsCarbonated { get; private set; }

        public override string ToString()
        {
            return base.ToString()+ String.Format("Carbonated: {0}", IsCarbonated ? "yes" : "no");
        }

        #endregion
    }
}