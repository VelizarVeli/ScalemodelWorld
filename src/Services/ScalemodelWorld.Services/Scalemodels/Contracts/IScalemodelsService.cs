using System.Collections.Generic;
using System.Threading.Tasks;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Common.Scalemodels.ViewModels;

namespace ScalemodelWorld.Services.Scalemodels.Contracts
{
    public interface IScalemodelsService
    {
        Task AddScalemodelAsync(AvailableScalemodelBindingModel scalemodel, string id);
        Task<IEnumerable<AllModelsViewModel>> AvailableAll(string id);
        Task<AvailableScalemodelBindingModel> GetAvailableScalemodelDetailsAsync(int id, string username);
        Task<IEnumerable<AllModelsViewModel>> StartedAll(string id);
        Task StartNewBuildAsync(int id, string userId);
        Task AvailableDeleteAsync(int modelId, string userId);
        Task AvailableEditAsync(AvailableScalemodelBindingModel scalemodel, int modelId, string userId);
    }
}
