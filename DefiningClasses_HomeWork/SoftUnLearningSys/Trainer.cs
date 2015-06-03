using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUnLearningSys
{
    internal class Trainer : Person
    {
        private static List<string> courses = new List<string>(); 

         public Trainer(string firstName, string lastName, int age)
             :base(firstName,lastName,age)
        {
        }
         public List<string> Courses
         {
             get { return courses; }
             set { courses = value; }
         }
         public void CreateCourse(string course)
         {
             courses.Add(course);
             Console.WriteLine("Course {0} created!", course);
         }
    }
}
