using System;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public abstract class Instrument : Article,IInstrument
    {
        private string _color;
        protected Instrument(string make, string model, decimal price,string color) : base(make, model, price)
        {
            this.Color = color;
        }

        public string Color
        {
            get { return this._color; } 
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format("The instrument {0} can not be empty",Color));
                }
                this._color = value;
            }
        }

        public bool IsElectronic { get; protected set; }

        public override string ToString()
        {
            return base.ToString() + string.Format("Color: {0}", this.Color) + Environment.NewLine +
                   string.Format("Electronic: {0}", this.IsElectronic ? "yes" : "no") + Environment.NewLine;
        }
    }
}
