using System.Collections.Generic;
using System.Threading.Tasks;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Common.Scalemodels.ViewModels;

namespace ScalemodelWorld.Services.Scalemodels.Contracts
{
    public interface IScalemodelsService
    {
        Task AddScalemodelAsync(AvailableScalemodelBindingModel scalemodel, string id);
        Task<IEnumerable<AllAvailableModelsViewModel>> AvailableAll(string id);
        Task<AvailableScalemodelBindingModel> GetAvailableScalemodelDetailsAsync(int id, string username);
        Task<IEnumerable<AllStartedModelsViewModel>> StartedAll(string userId);
        Task StartNewBuildAsync(int id, string userId);
        Task AvailableDeleteAsync(int modelId, string userId);
        Task AvailableEditAsync(AvailableScalemodelBindingModel scalemodel, int modelId, string userId);
        Task<StartedScalemodelBindingModel> GetStartedScalemodelDetailsAsync(int id, string username);
        Task FinishBuildAsync(int id, string userId);
        Task StartedDeleteAsync(int modelId, string userId);
        Task StartedEditAsync(StartedScalemodelBindingModel scalemodel, int modelId, string userId);
        Task<IEnumerable<AllCompletedModelsViewModel>> CompletedAll(string userId);
        Task<IEnumerable<WishlistScalemodelBindingModel>> WishlistAll(string id);
        Task AddWishAsync(WishlistScalemodelBindingModel scalemodel, string id);
    }
}
