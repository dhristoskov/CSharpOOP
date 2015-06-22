using System;
using System.Runtime.CompilerServices;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class MainCourse : Meal, IMainCourse
    {
        public MainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan,string type) 
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.Type = (MainCourseType) Enum.Parse(typeof (MainCourseType), type);
        }

        public MainCourseType Type { get; private set; }

        public override string ToString()
        {
            return base.ToString() + "Type: " + this.Type;
        }
    }
}