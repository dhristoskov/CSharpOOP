using NightlifeEntertainment.Enums;
using NightlifeEntertainment.Interfaces;

namespace NightlifeEntertainment.Tickets
{
    public class StudentTicket : Ticket
    {
        public StudentTicket(IPerformance performance)
            : base(performance, TicketType.Student)
        {
        }

        protected override decimal CalculatePrice()
        {
            decimal studentsTicketPrice = base.CalculatePrice()*0.8m;
            return studentsTicketPrice;
        }
    }
}