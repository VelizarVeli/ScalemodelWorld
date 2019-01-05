using System.Collections.Generic;
using Scalemodel.Data.Models.Abstractions;
using Scalemodel.Data.Models.JunctionClasses;

namespace Scalemodel.Data.Models.Scalemodels
{
    public class AvailableScalemodel : MyModel
    {
        public AvailableScalemodel()
        {
            this.AvailableAndPurchasedAftermarkets = new HashSet<AvailableAftermarket>();
        }

        public ICollection<AvailableAftermarket> AvailableAndPurchasedAftermarkets { get; set; }
    }
}