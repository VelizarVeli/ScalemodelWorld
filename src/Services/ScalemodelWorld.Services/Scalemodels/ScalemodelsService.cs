using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Scalemodel.Data.Models;
using Scalemodel.Data.Models.Scalemodels;
using ScalemodelWorld.Common;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services;
using ScalemodelWorld.Services.Scalemodels.Contracts;

namespace ScalemodelWorld.Scalemodels.Services
{
    public class ScalemodelsService : BaseService, IScalemodelsService
    {
        public ScalemodelsService(ScalemodelWorldContext dbContext, 
            IMapper mapper, 
            UserManager<ScalemodelWorldUser> userManager) 
            : base(dbContext, mapper, userManager)
        {
        }

        public async Task AddScalemodelAsync(AddPurchasedScalemodelBindingModel scalemodel, string username)
        {
            CoreValidator.ThrowIfNull(scalemodel);

            var user = await this.GetUserByNamedAsync(username);

            var manifacturer = DbContext.Manifacturers.FirstOrDefault(m => m.Name == scalemodel.Manifacturer);
            if (manifacturer == null)
            {
                manifacturer = new Manifacturer
                {
                    Name = scalemodel.Manifacturer
                };

                this.DbContext.Manifacturers.Add(manifacturer);
                await this.DbContext.SaveChangesAsync();
            }

            var model = this.Mapper.Map<AvailableScalemodel>(scalemodel);

            user.PurchasedModels.Add(model);
            await this.DbContext.SaveChangesAsync();
        }
    }
}
