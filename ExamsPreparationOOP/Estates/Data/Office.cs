﻿using Estates.Interfaces;

namespace Estates.Data
{
    public class Office : BuildingEstate, IOffice
    {
        public Office()
        {
            base.Type = EstateType.Office;
        }
    }
}