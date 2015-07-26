using NightlifeEntertainment.Enums;
using NightlifeEntertainment.Interfaces;

namespace NightlifeEntertainment.Tickets
{
    public class RegularTicket : Ticket
    {
        public RegularTicket(IPerformance performance)
            : base(performance, TicketType.Regular)
        {
        }
    }
}
