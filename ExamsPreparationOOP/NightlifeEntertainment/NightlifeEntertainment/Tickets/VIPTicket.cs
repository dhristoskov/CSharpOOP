using NightlifeEntertainment.Enums;
using NightlifeEntertainment.Interfaces;

namespace NightlifeEntertainment.Tickets
{
    public class VIPTicket:Ticket
    {
        public VIPTicket(IPerformance performance) 
            : base(performance, TicketType.VIP)
        {
        }

        protected override decimal CalculatePrice()
        {
            decimal vipTicketPrice = base.CalculatePrice()*1.5m;
            return vipTicketPrice;
        }
    }
}