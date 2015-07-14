using System;
using Estates.Interfaces;

namespace Estates.Data
{
    public abstract class BuildingEstate : Estate, IBuildingEstate
    {
        private const int RoomsMaxRange = 20;
        private int _rooms;

        public int Rooms
        {
            get { return this._rooms; }
            set
            {
                if (value > RoomsMaxRange || value < 0)
                {
                    throw new ArgumentOutOfRangeException("Rooms", "Rooms can not be more than 10 and less than 0!");
                }
                this._rooms = value;
            }
        }

        public bool HasElevator { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                   string.Format(", Rooms: {0}, Elevator: {1}", this.Rooms, this.HasElevator ? "Yes" : "No");
        }
    }
}