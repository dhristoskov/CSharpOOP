using System;
using MusicShopManager.Interfaces;

namespace MusicShopManager.Models
{
    public class AcousticGuitar : Guitar, IAcousticGuitar
    {
        public AcousticGuitar(string make, string model, decimal price, string color, string bodyWood, string fingerboardWood,bool caseInclude, StringMaterial stringMaterial) : base(make, model, price, color, bodyWood, fingerboardWood)
        {
            this.CaseIncluded = caseInclude;
            this.StringMaterial = stringMaterial;
            base.IsElectronic = false;
            this.NumberOfStrings = 6;
        }

        public bool CaseIncluded { get; private set; }
        public StringMaterial StringMaterial { get; private set; }

        public override string ToString()
        {
            return base.ToString() + string.Format("Case included: {0}", this.CaseIncluded ? "yes" : "no")
                   + Environment.NewLine + string.Format("String material: {0}", this.StringMaterial)
                   + Environment.NewLine;
        }
    }
}
