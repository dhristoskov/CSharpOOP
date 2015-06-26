using System;
using System.Collections.Generic;
using System.Text;
using Cosmetics.Common;

namespace Cosmetics.Products
{
    public class Toothpaste : Products.Product, Contracts.IToothpaste
    {
        private readonly IList<string> _ingredientsList;
        private string _ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender,IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this._ingredientsList = ingredients;
        }

        public string Ingredients
        {
            get            
            {
                if (_ingredients == null)
                {
                    foreach (var ingredient in this._ingredientsList)
                    {
                        if (ingredient.Length < 4 || ingredient.Length > 12)
                        {
                            throw new ArgumentException(String.Format("Each ingredient must be between {0} and {1} symbols long!", 4, 12));
                        }
                    }
                    this._ingredients = String.Join(", ", _ingredientsList); 
                }
                return _ingredients;
            }

        }

        public override string Print()
        {
            StringBuilder paste = new StringBuilder(base.Print());
            paste.AppendFormat("  * Ingredients: {0}", this.Ingredients);

            return paste.ToString();
        }
    }
}
