using System;
using Estates.Interfaces;

namespace Estates.Data
{
    public class House : Estate,IHouse
    {
        private int _floors;

        public House()
        {
            this.Type = EstateType.House;
        }

        public int Floors
        {
            get { return this._floors; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this._floors = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(", Floors: {0}", this.Floors);
        }
    }
}