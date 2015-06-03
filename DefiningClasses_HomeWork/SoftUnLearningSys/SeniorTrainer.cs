using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUnLearningSys
{
    internal class SeniorTrainer : Trainer
    {
         public SeniorTrainer(string firstName, string lastName, int age)
             :base(firstName,lastName,age)
        {
        }
         public void RemoveCourse(string course)
         {
             base.Courses.Remove(course);
             Console.WriteLine("Course {0} removed!", course);
         }
    }
}
