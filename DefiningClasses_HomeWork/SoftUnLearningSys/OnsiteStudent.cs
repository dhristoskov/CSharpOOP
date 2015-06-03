using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUnLearningSys
{
    internal class OnsiteStudent : CurrentStudent
    {
        public int NumberVisits { get; set; } 

         public OnsiteStudent(string firstName, string lastName, int age,long studentNum, decimal averageGrade,string currentCourse,int numberVisits)
            :base(firstName,lastName,age,studentNum,averageGrade,currentCourse)
        {
            this.NumberVisits = numberVisits;
        }

         public override string ToString()
         {
             return base.ToString() + " :Onsite student";
         }
    }
}
