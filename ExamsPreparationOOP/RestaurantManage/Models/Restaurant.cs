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

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.Recipes= new List<IRecipe>();
        } 

        public string Name
        {
            get { return this._name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The Name is required");
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
                    throw new ArgumentException("The Location is required");
                }
                this._location = value;
            }
        }
        public IList<IRecipe> Recipes { get; private set; }

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
            StringBuilder restaurantMenu = new StringBuilder();
            restaurantMenu.AppendFormat("***** {0} - {1} *****\n", this.Name, this.Location);

            if (!this.Recipes.Any())
            {
                restaurantMenu.Append("No recipes... yet");
                return restaurantMenu.ToString();
            }
                     
            var orderedRecipe = this.Recipes.OrderBy(s => s.Name).ToList();
            var drinks = orderedRecipe.OfType<Drink>().ToList();

            if (drinks.Any())
            {
                restaurantMenu.AppendLine("~~~~~ DRINKS ~~~~~");

                foreach (var drink in drinks)
                {
                    restaurantMenu.Append(drink.ToString());
                }
            }

            var salads = orderedRecipe.OfType<Salad>().ToList();

            if (salads.Any())
            {
                restaurantMenu.AppendLine("~~~~~ SALADS ~~~~~");

                foreach (var salad in salads)
                {
                    restaurantMenu.Append(salad.ToString());
                }
            }

            var mainCourses = orderedRecipe.OfType<MainCourse>().ToList();
            if (mainCourses.Any())
            {
                restaurantMenu.AppendLine("~~~~~ MAIN COURSES ~~~~~");

                foreach (var mainCourse in mainCourses)
                {
                    restaurantMenu.Append(mainCourse.ToString());
                }
            }

            var deserts = orderedRecipe.OfType<Dessert>().ToList();

            if (deserts.Any())
            {
                restaurantMenu.AppendLine("~~~~~ DESSERTS ~~~~~");

                foreach (var dessert in deserts)
                {
                    restaurantMenu.Append(dessert.ToString());
                }
            }

            return restaurantMenu.ToString();
        }
    }
}