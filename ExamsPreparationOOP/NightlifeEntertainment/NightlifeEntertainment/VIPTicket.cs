using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NightlifeEntertainment
{
    public class VipTicket : Ticket
    {
        public VipTicket(IPerformance performance) 
            : base(performance, TicketType.VIP)
        {
        }

        protected override decimal CalculatePrice()
        {
            decimal vipPrice = base.CalculatePrice();
            return vipPrice*1.5m;
        }
    }
}