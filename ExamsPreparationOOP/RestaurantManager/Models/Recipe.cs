using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public abstract class Recipe:IRecipe
    {
        private string _name;
        private decimal _price;
        protected int _calories;
        private int _quantityPerServing;      
        protected int _timeToPrepare;     

        protected Recipe(string name,decimal price, int calories,int quantityPerServing,int timeToPrepare, MetricUnit unit)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantityPerServing;
            this.TimeToPrepare = timeToPrepare;
            this.Unit = unit;
        }

        #region Propertie   

        public MetricUnit Unit { get; private set; }

        public string Name
        {
            get { return this._name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The <parameter> is required");
                }
                this._name = value;
            }
        }

        public decimal Price
        {
            get { return this._price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The <parameter> must be positive");
                }
                this._price = value;
            }
        }

        public int Calories
        {
            get { return this._calories; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The <parameter> must be positive!");
                }
                this._calories = value;
            }
        }

        public int QuantityPerServing
        {
            get { return this._quantityPerServing; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The <parameter> must be positive");
                }
                this._quantityPerServing = value;
            }
        }       
        public int TimeToPrepare
        {
            get { return this._timeToPrepare; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The <parameter> must be positive");
                }
                this._timeToPrepare = value;
            }
        }

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("==  {0} == ${1:F2}", this.Name, this.Price));
            sb.AppendLine(string.Format("Per serving: {0} {1}, {2} kcal", this.QuantityPerServing, this.Unit == MetricUnit.Grams ? "g" : "ml",
                this.Calories));
            sb.AppendLine(string.Format("Ready in {0} minutes", this.TimeToPrepare));

            return sb.ToString();
        }
    }
}


