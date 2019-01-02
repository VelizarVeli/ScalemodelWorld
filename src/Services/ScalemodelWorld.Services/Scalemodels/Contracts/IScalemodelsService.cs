using System.Threading.Tasks;

namespace ScalemodelWorld.Services.Scalemodels.Contracts
{
    public interface IScalemodelsService
    {
        Task<int> AddScalemodelAsync(string username);
    }
}
