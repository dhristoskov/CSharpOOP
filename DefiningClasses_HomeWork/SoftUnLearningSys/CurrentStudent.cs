using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUnLearningSys
{
    internal class CurrentStudent : Student
    {
        public string CurrentCourse { get; set; }

         public CurrentStudent(string firstName, string lastName, int age,long studentNum, decimal averageGrade,string currentCourse)
            :base(firstName,lastName,age,studentNum,averageGrade)
        {
            this.CurrentCourse = currentCourse;
        }
    }
}
