using System;
using System.Text;
using RestaurantManager.Interfaces;

namespace RestaurantManager.Models
{
    public class MainCourse : Meal, IMainCourse
    {
        public MainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, string type) 
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.Type = (MainCourseType) Enum.Parse(typeof (MainCourseType), type);
        }

        public MainCourseType Type { get; private set; }

        public override string ToString()
        {
            StringBuilder mainCourse = new StringBuilder(base.ToString());
            mainCourse.AppendLine();
            mainCourse.AppendLine(string.Format("Type: {0}", this.Type));

            return mainCourse.ToString();
        }
    }
}