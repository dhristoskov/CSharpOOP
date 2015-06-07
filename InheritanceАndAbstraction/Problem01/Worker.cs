using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem01
{
    internal class Worker : Human
    {
        private const decimal workDays = 5;
        private decimal weekSalary;
        private decimal workHoursPerDay;

         public Worker (string firstName, string lastName,decimal weekSalary, decimal workHoursPerDay)
            :base (firstName,lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

         public decimal WorkHoursPerDay
         {
             get { return this.workHoursPerDay; }
             set
             {
                 if (value < 0)
                 {
                     throw new ArgumentOutOfRangeException();
                 }
                 this.workHoursPerDay = value;
             }
         }

         public decimal WeekSalary
         {
             get { return this.weekSalary; }
             set
             {
                 if (value < 0)
                 {
                     throw new ArgumentOutOfRangeException();
                 }
                 this.weekSalary = value;
             }
         }
         public decimal MoneyPerHour
         {
             get { return this.WeekSalary/(this.WorkHoursPerDay * workDays); }
         }
         public override string ToString()
         {
             return base.ToString() + String.Format(",Salary:{0:C},Hours/Day:{1:f2},Money/hours:{2:C}", this.WeekSalary, this.WorkHoursPerDay, this.MoneyPerHour);
         }
        
    }
}
