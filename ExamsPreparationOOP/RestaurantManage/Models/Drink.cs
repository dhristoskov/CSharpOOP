using System;
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Drink : Recipe, IDrink
    {
        private const int MaxCaloriesInDrink = 100;
        private const int MaxTimeToPrepareADrink = 20;

        public Drink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            base.Unit = MetricUnit.Milliliters;
            this.IsCarbonated = isCarbonated;
        }

        public override int Calories
        {
            get { return base._calories; }
            set
            {
                if (value < 0 || value > MaxCaloriesInDrink)
                {
                    throw new ArgumentException("The Calories must be positive and smaller than 100 cal");
                }
                base._calories = value;
            }
        }

        public override int TimeToPrepare
        {
            get { return base._timeToPrepare; }
            set
            {
                if (value < 0 || value > MaxTimeToPrepareADrink)
                {
                    throw new ArgumentException("The TimeToPrepare must be positive and smaller than 20 min");
                }
                base._timeToPrepare = value;
            }
        }

        public bool IsCarbonated { get; private set; }

        public override string ToString()
        {
            StringBuilder drink = new StringBuilder(base.ToString());
            drink.AppendLine();
            drink.AppendLine(string.Format("Carbonated: {0}", IsCarbonated ? "yes" : "no"));

            return drink.ToString();
        }
    }
}