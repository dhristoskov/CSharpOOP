using System;
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Salad : Meal, ISalad
    {
        public Salad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta)
            : base(name, price, calories, quantityPerServing, timeToPrepare, true)
        {
            this.ContainsPasta = containsPasta;
        }

        public bool ContainsPasta { get; private set; }

        public override string ToString()
        {
            StringBuilder salad = new StringBuilder(base.ToString());
            salad.AppendLine();
            salad.AppendLine(string.Format("Contains pasta: {0}", this.ContainsPasta ? "yes" : "no"));

            return salad.ToString();
        }
    }
}