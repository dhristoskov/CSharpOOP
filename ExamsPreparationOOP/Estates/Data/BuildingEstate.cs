using System;
using Estates.Interfaces;

namespace Estates.Data
{
    public abstract class BuildingEstate : Estate, IBuildingEstate
    {
        private int _rooms;
        public bool HasElevator { get; set; }
     
        public int Rooms
        {
            get { return this._rooms; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this._rooms = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                   String.Format(", Rooms: {0}, Elevator: {1}", this.Rooms, this.HasElevator ? "Yes" : "No");
        }
    }
}