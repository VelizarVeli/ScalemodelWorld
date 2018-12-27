using System.Collections.Generic;
using ScalemodelWorld.Web.ViewModels.Scalemodels;

namespace ScalemodelWorld.Web.ViewModels.Home
{
    public class LoggedInIndexViewModel
    {
        //public ICollection<BaseScalemodelViewModel> Available { get; set; }

        //public ICollection<BaseScalemodelViewModel> Completed { get; set; }

        public IEnumerable<BaseScalemodelViewModel> Started { get; set; }

        //public ICollection<BaseScalemodelViewModel> WishList { get; set; }
    }
}
