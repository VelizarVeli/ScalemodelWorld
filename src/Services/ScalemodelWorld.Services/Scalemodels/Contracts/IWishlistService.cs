using System.Collections.Generic;
using System.Threading.Tasks;
using ScalemodelWorld.Common.Scalemodels.BindingModels;

namespace ScalemodelWorld.Services.Scalemodels.Contracts
{
    public interface IWishlistService
    {
        Task AddWishAsync(WishlistScalemodelBindingModel scalemodel, string id);
        Task<IEnumerable<WishlistScalemodelBindingModel>> WishlistAll(string id);
    }
}
