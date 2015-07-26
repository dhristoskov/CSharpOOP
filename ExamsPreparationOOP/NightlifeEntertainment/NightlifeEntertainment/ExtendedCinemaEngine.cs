using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NightlifeEntertainment.Enums;
using NightlifeEntertainment.Interfaces;
using NightlifeEntertainment.Performances;
using NightlifeEntertainment.Tickets;
using NightlifeEntertainment.Venues;

namespace NightlifeEntertainment
{
    public class ExtendedCinemaEngine : CinemaEngine
    {
        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "opera":
                    var operaHall = new OperaHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(operaHall);
                    break;
                case "sports_hall":
                    var sportsHall = new SportsHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(sportsHall);
                    break;
                case "concert_hall":
                    var concertHall = new ConcertHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(concertHall);
                    break;
                default:
                    base.ExecuteInsertVenueCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            var venue = this.GetVenue(commandWords[5]);
            switch (commandWords[2])
            {
                case "theatre":                    
                    var theatre = new Theatre(commandWords[3], decimal.Parse(commandWords[4]), venue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(theatre);
                    break;
                case "concert":
                    var concert = new Concert(commandWords[3], decimal.Parse(commandWords[4]), venue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(concert);
                    break;
                default:
                    base.ExecuteInsertPerformanceCommand(commandWords);
                    break;
            }            
        }

        protected override void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            var venue = this.GetVenue(commandWords[2]);
            var performance = this.GetPerformance(commandWords[3]);
            switch (commandWords[1])
            {
                case "student":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new StudentTicket(performance));
                    }
                    break;
                case "vip":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new VIPTicket(performance));
                    }
                    break;
                default:
                    base.ExecuteSupplyTicketsCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportCommand(string[] commandWords)
        {
            var performance = base.GetPerformance(commandWords[1]);
            var soldTickets = performance.Tickets.Where(ticket => ticket.Status == TicketStatus.Sold).ToList();
            decimal totalIncome = soldTickets.Sum(ticket => ticket.Price);

            this.Output.AppendFormat("{0}: {1} ticket(s), total: ${2:f2}", performance.Name, soldTickets.Count(), totalIncome)
                .AppendLine().AppendFormat("Venue: {0} ({1})", performance.Venue.Name, performance.Venue.Location)
                .AppendLine().AppendFormat("Start time: {0}", performance.StartTime).AppendLine();
        }

        protected override void ExecuteFindCommand(string[] commandWords)
        {
            DateTime time = DateTime.Parse(commandWords[2] + " " + commandWords[3]);
            string word = commandWords[1];
            var foundPerformances =
                this.FindPerformances(time).Where(perform => perform.Name.ToLower().Contains(commandWords[1].ToLower()));
            var foundVenues = this.Venues.Where(venue => venue.Name.ToLower().Contains(commandWords[1].ToLower())).OrderBy(venue => venue.Name);

            this.PrintResult(foundPerformances, foundVenues, time, word);
        }

        private IEnumerable<IPerformance> FindPerformances(DateTime time)
        {
            return
                this.Performances.Where(perform => perform.StartTime >= time)
                    .OrderBy(perform => perform.StartTime)
                    .ThenByDescending(perform => perform.BasePrice)
                    .ThenBy(perform => perform.Name);
        }

        private void PrintResult(IEnumerable<IPerformance> foundPerformances, IEnumerable<IVenue> foundVenues,
            DateTime time, string word)
        {
            this.Output.AppendLine("Search for \"" + word + "\"").AppendLine("Performances:");
            if (foundPerformances.Any())
            {
                this.Output.AppendLine(string.Join(Environment.NewLine,
                    foundPerformances.Select(perform => "-" + perform.Name)));
            }
            else
            {
                this.Output.AppendLine("no results");
            }
            this.Output.AppendLine("Venues:");
            if (foundVenues.Any())
            {
                foreach (var venue in foundVenues)
                {
                    this.Output.AppendLine("-" + venue.Name);
                    var foundInVenue = this.FindPerformances(time).Where(perform => perform.Venue == venue);
                    if (foundInVenue.Any())
                    {
                        this.Output.AppendLine(string.Join(Environment.NewLine,
                            foundInVenue.Select(perform => "--" + perform.Name)));
                    }
                }
            }
            else
            {
                this.Output.AppendLine("no results");
            }
        }
    }
}
