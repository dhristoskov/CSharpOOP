using System;
using Estates.Interfaces;

namespace Estates.Data
{
    public class House:Estate,IHouse
    {
        private const int FloorsMaxRange = 10;
        private int _floors;

        public House()
        {
            base.Type = EstateType.House;
        }

        public int Floors
        {
            get { return this._floors; }
            set
            {
                if (value > FloorsMaxRange || value < 0)
                {
                    throw new ArgumentOutOfRangeException("Floors","Floors can be greater than 10 and less than 0!");
                }
                this._floors = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Floors: {0}", this.Floors);
        }
    }
}