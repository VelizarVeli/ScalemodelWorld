using Scalemodel.Data.Models.Abstractions;

namespace Scalemodel.Data.Models.Scalemodels
{
    public class WishScalemodel : BaseModel
    {
        public string Userd { get; set; }
        public ScalemodelWorldUser User { get; set; }
    }
}