using System;
using System.Collections.Generic;
using Scalemodel.Data.Models.Abstractions;
using Scalemodel.Data.Models.JunctionClasses;

namespace Scalemodel.Data.Models.Scalemodels
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