using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUnLearningSys
{
    internal class GraduateStudent : Student
    {
         public GraduateStudent(string firstName, string lastName, int age,long studentNum, decimal averageGrade)
            :base(firstName,lastName,age,studentNum,averageGrade)
        {            
        }

         public override string ToString()
         {
             return base.ToString() + " :Graduate student";
         }
    }
}
