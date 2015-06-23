using System;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public class ElectricGuitar : Guitar, IElectricGuitar
    {
        private int _numberofadapters;
        private int _numberOfFrets;

        public ElectricGuitar(string make, string model, decimal price, string color,
            string bodyWood, string fingerboardWood, int numberOfAdapters, int numberOfFrets) : base(make, model, price, color, bodyWood, fingerboardWood)
        {
            base.IsElectronic = true;
            this.NumberOfStrings = 6;
            this.NumberOfAdapters = numberOfAdapters;
            this.NumberOfFrets = numberOfFrets;

        }

        public int NumberOfAdapters
        {
            get { return this._numberofadapters; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format("Electric guitar cannot come with negative {0}",NumberOfAdapters));
                }
                this._numberofadapters = value;
            }
        }

        public int NumberOfFrets
        {
            get { return this._numberOfFrets; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format("Electric guitar cannot come with negative or zero {0}",NumberOfAdapters));
                }
                this._numberOfFrets = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Adapters: {0}", this.NumberOfAdapters) +
                   Environment.NewLine + string.Format("Frets: {0}", this.NumberOfFrets) + Environment.NewLine;
        }
    }
}
