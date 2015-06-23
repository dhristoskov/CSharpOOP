using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public class BassGuitar : Guitar,IBassGuitar
    {
        public BassGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood) : base(make, model, price, color, bodyWood, fingerboardWood)
        {
            this.IsElectronic = true;
            this.NumberOfStrings = 4;
        }
    }
}
