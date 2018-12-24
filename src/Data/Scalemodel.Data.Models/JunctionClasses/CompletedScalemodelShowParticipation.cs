using Scalemodels.Models.Modelshows;
using Scalemodels.Models.Scalemodels;

namespace Scalemodels.Models.JunctionClasses
{
    public class CompletedScalemodelShowParticipation
    {
        public int Id { get; set; }

        public int ModelshowId { get; set; }
        public ModelShow Modelshow { get; set; }

        public int CompletedScalemodelId { get; set; }
        public CompletedScalemodel CompletedScalemodel { get; set; }
    }
}