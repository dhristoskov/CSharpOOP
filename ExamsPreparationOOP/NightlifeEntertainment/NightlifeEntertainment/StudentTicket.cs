using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NightlifeEntertainment
{
    public class StudentTickect : Ticket
    {
        public StudentTickect(IPerformance performance)
            : base(performance, TicketType.Student)
        {
        }

        protected override decimal CalculatePrice()
        {
            decimal studentPrice = base.CalculatePrice();
            return studentPrice*0.8m;
        }
    }
}