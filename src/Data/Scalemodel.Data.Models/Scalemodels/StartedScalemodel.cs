using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; } = DateTime.UtcNow;

        public ICollection<StartedAftermarket> StartAftermarkets { get; set; }
    }
}