using System.Linq;
using Estates.Interfaces;

namespace Estates.Data
{
    class ExtendedEstateEngine : Engine.EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {              
                case "find-rents-by-location":
                    return this.ExecuteFindRentsByLocationCommand(cmdArgs[0]);
                case "find-rents-by-price":
                    return this.ExecuteFindRentsByPriceCommand(cmdArgs[0],cmdArgs[1]);
                default:
                    return base.ExecuteCommand(cmdName, cmdArgs);
            }
        }

        private string ExecuteFindRentsByLocationCommand(string location)
        {
            var offers = this.Offers
                .Where(offer => offer.Estate.Location == location && offer.Type == OfferType.Rent)
                .OrderBy(offer => offer.Estate.Name);
            return FormatQueryResults(offers);
        }

        private string ExecuteFindRentsByPriceCommand(string min, string max)
        {
            decimal minPrice = decimal.Parse(min);
            decimal maxPrice = decimal.Parse(max);

            var offers = this.Offers
                .Where(offer => offer.Type == OfferType.Rent)
                .Cast<IRentOffer>()
                .Where(offer => offer.PricePerMonth >= minPrice && offer.PricePerMonth <= maxPrice)
                .OrderBy(offer => offer.PricePerMonth).ThenBy(offer => offer.Estate.Name);
            return FormatQueryResults(offers);
        }
    }
}