using System;
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public abstract class Recipe : IRecipe
    {
        private string _name;
        private decimal _price;
        protected int _calories;
        protected int _timeToPrepare;
        private int _quantityPerServing;
        

        protected Recipe(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantityPerServing;
            this.TimeToPrepare = timeToPrepare;
        }

        #region Properties
        public string Name
        {
            get { return this._name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw  new ArgumentException("The Name is required");
                }
                this._name = value;
            }
        }

        public decimal Price
        {
            get { return this._price; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The Price must be positive");
                }
                this._price = value;
            }
        }
        public virtual int Calories
        {
            get { return this._calories; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The Calories must be positive");
                }
                this._calories = value;
            }
        }
        public int QuantityPerServing
        {
            get { return this._quantityPerServing; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The QuantityPerServing must be positive");
                }
                this._quantityPerServing = value;
            }
        }
        
        public virtual int TimeToPrepare
        {
            get { return this._timeToPrepare; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The TimeToPrepare must be positive");
                }
                this._timeToPrepare = value;
            }
        }
        public MetricUnit Unit { get; set; }

        #endregion


        public override string ToString()
        {
            StringBuilder recipe = new StringBuilder();
            recipe.AppendLine(string.Format("==  {0} == ${1:F2}", this.Name, this.Price));
            recipe.AppendLine(string.Format("Per serving: {0} {1}, {2} kcal", this.QuantityPerServing, this.Unit == MetricUnit.Grams ? "g" : "ml",
                this.Calories));
            recipe.Append(string.Format("Ready in {0} minutes", this.TimeToPrepare));

            return recipe.ToString();
        }

    }
}