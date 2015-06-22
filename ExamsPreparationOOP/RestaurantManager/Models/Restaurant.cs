using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class Restaurant : IRestaurant
    {
        private string _name;
        private string _location;
        private IList<IRecipe> _recipes;

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.Recipes = new List<IRecipe>();
        }

        #region Properties

        public string Name
        {
            get { return this._name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can not be null or empty space!");
                }
                this._name = value;
            }
        }

        public string Location
        {
            get { return this._location; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Location can not be null or empty space!");
                }
                this._location = value;
            }
        }

        public IList<IRecipe> Recipes
        {
            get { return this._recipes; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Recipe list can not be empty!");
                }
                this._recipes = value;
            }
        }

        #endregion

        public void AddRecipe(IRecipe recipe)
        {
            this.Recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            this.Recipes.Remove(recipe);
        }

        public string PrintMenu()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("***** {0} - {1} *****\n", this.Name, this.Location);
            if (_recipes.Count <= 0)
            {
                sb.AppendLine("No recipes... yet");
                return sb.ToString();
            }
            else
            {
                _recipes = _recipes.Select(s => s).OrderBy(s => s.Name[0]).ToList();
            }
            var drinks = _recipes.OfType<Drink>().ToArray();
            if (drinks.Length > 0)
            {               
                sb.AppendLine("~~~~~ DRINKS ~~~~~");
                foreach (var drink in drinks)
                {
                    sb.AppendLine(drink.ToString());
                }
            }
            var salads = _recipes.OfType<Salad>().ToArray();
            if (salads.Length > 0)
            {             
                sb.AppendLine("~~~~~ SALADS ~~~~~");
                foreach (var salad  in salads)
                {
                    sb.AppendLine(salad.ToString());
                }
            }
            var maincourses = _recipes.OfType<MainCourse>().ToArray();
            if (maincourses.Length > 0)
            {
                sb.AppendLine("~~~~~ MAIN COURSES ~~~~~");
                foreach (var maincourse in maincourses)
                {
                    sb.AppendLine(maincourse.ToString());
                }
            }
            var deserts = _recipes.OfType<Dessert>().ToArray();
            if (deserts.Length > 0)
            {
                sb.AppendLine("~~~~~ DESSERTS ~~~~~");
                foreach (var dessert in deserts)
                {
                    sb.AppendLine(dessert.ToString());
                }
            }
            return sb.ToString();
        }
    }
}