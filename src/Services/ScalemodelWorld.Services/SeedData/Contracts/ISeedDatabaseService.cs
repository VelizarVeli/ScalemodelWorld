using System.Threading.Tasks;

namespace ScalemodelWorld.Services.SeedData.Contracts
{
    public interface ISeedDatabaseService
    {
        Task StartSeedingPurchasedAsync(string userId, string path);
        Task StartSeedingStartedAsync(string userId, string path);
        Task StartSeedingCompletedAsync(string userId, string path);
        Task StartSeedingWishlistAsync(string userId, string path);
    }
}
