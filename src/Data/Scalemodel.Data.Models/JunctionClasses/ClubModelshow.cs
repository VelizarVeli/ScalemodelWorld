using Scalemodel.Data.Models.Abstractions;
using Scalemodel.Data.Models.Modelshows;

namespace Scalemodel.Data.Models.JunctionClasses
{
    public class ClubModelshow : BaseId
    {
        public int ClubId { get; set; }
        public Club Club { get; set; }

        public int ModelshowId { get; set; }
        public ModelShow ModelShow { get; set; }
    }
}
