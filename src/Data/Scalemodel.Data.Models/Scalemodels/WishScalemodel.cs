using Scalemodel.Data.Models.Abstractions;

namespace Scalemodel.Data.Models.Scalemodels
{
    public class WishScalemodel : BaseModel
    {
        public int Userd { get; set; }
        public ScalemodelWorldUser User { get; set; }
    }
}