using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUnLearningSys
{
    internal class OnlineStudent : CurrentStudent
    {
         public OnlineStudent(string firstName, string lastName, int age,long studentNum, decimal averageGrade, string currentCourse)
            :base(firstName,lastName,age,studentNum,averageGrade,currentCourse)
        {            
        }

         public override string ToString()
         {
             return base.ToString() + " :Online student";
         }
    }

}
