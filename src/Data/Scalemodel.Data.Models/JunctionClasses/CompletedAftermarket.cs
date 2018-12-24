using Scalemodels.Models.Scalemodels;

namespace Scalemodels.Models.JunctionClasses
{
    public class CompletedAftermarket
    {
        public int Id { get; set; }

        public int CompletedScalemodelId { get; set; }
        public CompletedScalemodel CompletedScalemodel { get; set; }

        public int CompletedAftermarketId { get; set; }
        public Aftermarket Aftermarket { get; set; }
    }
}