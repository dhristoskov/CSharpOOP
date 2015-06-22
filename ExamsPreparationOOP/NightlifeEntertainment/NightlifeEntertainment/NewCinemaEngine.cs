using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NightlifeEntertainment
{
    public class NewCinemaEngine : CinemaEngine
    {
        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "opera":
                    var opera = new OperaHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(opera);
                    break;
                case "concert_hall":
                    var concertHall = new ConcertHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(concertHall);
                    break;
                case "sports_hall":
                    var sportHall = new SportHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(sportHall);
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
                case "concert":
                    var concert = new Movie(commandWords[3], decimal.Parse(commandWords[4]), venue,
                        DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(concert);
                    break;
                case "theatre":
                    var theatre = new Movie(commandWords[3], decimal.Parse(commandWords[4]), venue,
                        DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(theatre);
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
                        performance.AddTicket(new StudentTickect(performance));
                    }
                    break;
                case "vip":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new VipTicket(performance));
                    }
                    break;
                default:
                    base.ExecuteSupplyTicketsCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportCommand(string[] commandWords)
        {
            var perform = this.GetPerformance(commandWords[1]);
            var soldTickets = perform.Tickets.Where(a => a.Status == TicketStatus.Sold);
            decimal totalSoldPrice = soldTickets.Sum(a => a.Price);

            this.Output.AppendFormat("{0}: {1} ticket(s), total: ${2:f2}", perform.Name, soldTickets.Count(),totalSoldPrice)
                .AppendLine().AppendFormat("Venue: {0} ({1})", perform.Venue.Name, perform.Venue.Location)
                .AppendLine().AppendFormat("Start time: {0}", perform.StartTime);
        }

        protected override void ExecuteFindCommand(string[] commandWords)
        {
            DateTime time = DateTime.Parse(commandWords[2] + " " + commandWords[3]);
            string word = commandWords[1];
            var foundPerformances =
                this.FindPerformances(time).Where(perform => perform.Name.ToLower().Contains(commandWords[1].ToLower()));
            var foundVenues = this.Venues.Where(venue => venue.Name.ToLower().Contains(commandWords[1].ToLower())).OrderBy(venue=>venue.Name);

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
            DateTime time,string word)
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