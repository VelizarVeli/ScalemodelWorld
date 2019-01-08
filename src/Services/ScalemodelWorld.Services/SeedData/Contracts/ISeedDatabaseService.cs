using System.Threading.Tasks;

namespace ScalemodelWorld.Services.SeedData.Contracts
{
    public interface ISeedDatabaseService
    {
        Task StartSeedingAsync(string userId, string path, string category);
    }
}
