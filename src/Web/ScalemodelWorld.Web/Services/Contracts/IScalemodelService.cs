using System.Collections.Generic;
using ScalemodelWorld.Web.ViewModels.Scalemodels;

namespace ScalemodelWorld.Web.Services.Contracts
{
    public interface IScalemodelService
    {
        void Create(CreateScalemodelViewModel model);
        IList<BaseScalemodelViewModel> All();
    }
}
