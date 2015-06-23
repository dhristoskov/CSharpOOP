using System;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public abstract class Guitar : Instrument,IGuitar
    {
        private string _bodyWood;
        private string _fingerboardWood;

        public Guitar(string make, string model, decimal price, string color,
            string bodyWood, string fingerboardWood) : base(make, model, price, color)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fingerboardWood;
        }

        public string BodyWood
        {
            get
            {
                return this._bodyWood;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format("The acoustic guitar {0} should contain a value.", BodyWood));
                }
                this._bodyWood = value;
            }
        }

        public string FingerboardWood
        {
            get
            {
                return this._fingerboardWood;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format("The acoustic guitar {0} should contain a value.", BodyWood));
                }
                this._fingerboardWood = value;
            }
        }


        public int NumberOfStrings { get; protected set; }

        public override string ToString()
        {
            return base.ToString() + string.Format("Strings: {0}", this.NumberOfStrings) + Environment.NewLine
                   + string.Format("Body wood: {0}", this.BodyWood) + Environment.NewLine
                   + string.Format("Fingerboard wood: {0}", this.FingerboardWood)+ Environment.NewLine;
        }
    }
}
