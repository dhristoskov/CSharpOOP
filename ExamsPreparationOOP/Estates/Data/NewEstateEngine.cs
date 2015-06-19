using System;
using System.Linq;
using Estates.Interfaces;

namespace Estates.Data
{
    public class NewEstateEngine : Engine.EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "find-rents-by-location":
                    string location = cmdArgs[0];
                    return this.ExecuteRentsByLocation(location);
                case "find-rents-by-price":
                    decimal minPrice = decimal.Parse(cmdArgs[0]);
                    decimal maxPrice = decimal.Parse(cmdArgs[1]);
                    return this.ExecuteRentsByPrice(minPrice, maxPrice);
                default:
                    return base.ExecuteCommand(cmdName, cmdArgs);                    
            }
        }

        private string ExecuteRentsByLocation(string location)
        {
            var offers = this.Offers
                .Where(x => x.Estate.Location == location && x.Type == OfferType.Rent)
                .OrderBy(x => x.Estate.Name);
            return FormatQueryResults(offers);
        }

        private string ExecuteRentsByPrice(decimal minPrice, decimal maxPrice)
        {
            var offers = this.Offers
                .Where(x => x.Type == OfferType.Rent)
                .Cast<IRentOffer>()
                .Where(x => x.PricePerMonth >= minPrice && x.PricePerMonth <= maxPrice)
                .OrderBy(x => x.PricePerMonth)
                .ThenBy(x => x.Estate.Name);
            return FormatQueryResults(offers);
        }
    }
}