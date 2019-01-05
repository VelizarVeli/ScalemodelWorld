using System.Collections.Generic;
using System.Threading.Tasks;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Common.Scalemodels.ViewModels;

namespace ScalemodelWorld.Services.Scalemodels.Contracts
{
    public interface IScalemodelsService
    {
        Task AddScalemodelAsync(AddPurchasedScalemodelBindingModel scalemodel, string id);
        Task <IEnumerable<AvailableAllViewModel>> AvailableAll(string id);
    }
}
