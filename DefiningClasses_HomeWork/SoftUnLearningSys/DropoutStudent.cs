using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUnLearningSys
{
    internal class DropoutStudent : Student
    {
        public string DropoutReason { get; set; }

         public DropoutStudent(string firstName, string lastName, int age,long studentNum, decimal averageGrade,string dropoutReason)
            :base(firstName,lastName,age,studentNum,averageGrade)
        {
            this.DropoutReason = dropoutReason;
        }

         public void Reaplly()
         {
             Console.WriteLine("Name: {0} {1}, Age: {2},Student Number: {3},\nAverage Grade {4},Dropout Reason: {5}"
                 ,this.FirstName,this.LastName,this.Age,this.StudentNum,this.AverageGrade,this.DropoutReason);
         }

         public override string ToString()
         {
             return base.ToString() + string.Format(" :Dropout reason: {0}", this.DropoutReason);
         }
    }
}
