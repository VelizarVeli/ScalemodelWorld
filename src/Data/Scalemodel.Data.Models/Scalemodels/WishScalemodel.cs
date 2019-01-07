using Scalemodel.Data.Models.Abstractions;

namespace Scalemodel.Data.Models.Scalemodels
{
    public class WishScalemodel : BaseModel
    {
        public string UserId { get; set; }
        public ScalemodelWorldUser User { get; set; }
    }
}