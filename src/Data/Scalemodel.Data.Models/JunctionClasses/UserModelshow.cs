using Scalemodel.Data.Models.Abstractions;
using Scalemodel.Data.Models.Modelshows;

namespace Scalemodel.Data.Models.JunctionClasses
{
    public class UserModelshow : BaseId
    {
        public string ParticipantId { get; set; }
        public ScalemodelWorldUser Participant { get; set; }

        public int ModelshowId { get; set; }
        public ModelShow Modelshow { get; set; }
    }
}
