using System;
using System.Collections.Generic;
using Scalemodels.Models.Abstractions;
using Scalemodels.Models.JunctionClasses;

namespace Scalemodels.Models.Scalemodels
{
    public class StartedScalemodel : MyModel
    {
        public StartedScalemodel()
        {
            this.StartAftermarkets = new HashSet<StartedAftermarket>();
        }

        public DateTime StartingDate { get; set; }

        public ICollection<StartedAftermarket> StartAftermarkets { get; set; }
    }
}