﻿using Scalemodels.Models.Scalemodels;

namespace Scalemodels.Models.JunctionClasses
{
    public class AvailableAftermarket
    {
        public int Id { get; set; }

        public int AvailableScalemodelId { get; set; }
        public AvailableScalemodel AvailableScalemodel { get; set; }

        public int AvailableAftermarketId { get; set; }
        public Aftermarket Aftermarket { get; set; }
    }
}