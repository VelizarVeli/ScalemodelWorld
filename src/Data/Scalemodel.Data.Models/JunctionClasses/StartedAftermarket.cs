using Scalemodel.Data.Models.Scalemodels;

namespace Scalemodel.Data.Models.JunctionClasses
{
    public class StartedAftermarket
    {
        public int Id { get; set; }

        public int StartedScalemodelId { get; set; }
        public StartedScalemodel StartedScalemodel { get; set; }

        public int StartedAftermarketId { get; set; }
        public Aftermarket Aftermarket { get; set; }
    }
}