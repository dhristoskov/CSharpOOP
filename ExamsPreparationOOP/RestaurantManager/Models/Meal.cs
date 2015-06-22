using System;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public abstract class Meal : Recipe, IMeal
    {
        protected Meal(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare,bool isVegan) 
            : base(name, price, calories, quantityPerServing, timeToPrepare, MetricUnit.Grams)
        {
            this.IsVegan = isVegan;
        }

        public bool IsVegan { get; private set; }

        public void ToggleVegan()
        {       
            this.IsVegan=!IsVegan;   
        }

        public override string ToString()
        {
            return (IsVegan? "[VEGAN] " : "") + base.ToString();
        }
    }
}