using System;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public abstract class Meal:Recipe, IMeal
    {
        private bool _isVegan;

        protected Meal(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan) 
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.IsVegan = isVegan;
            base.Unit = MetricUnit.Grams;
        }

        public bool IsVegan
        {
            get { return _isVegan; }
            private set { _isVegan = value; }
        }

        public void ToggleVegan()
        {
            this.IsVegan = !IsVegan;
        }

        public override string ToString()
        {
            return (IsVegan ? "[VEGAN] " : string.Empty) + base.ToString();
        }
    }
}