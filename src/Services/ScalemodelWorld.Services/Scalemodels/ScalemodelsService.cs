using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        public async Task AddScalemodelAsync(AddPurchasedScalemodelBindingModel scalemodel, string id)
        {
            var user = await this.UserManager.FindByIdAsync(id);

            CoreValidator.ThrowIfNull(scalemodel);

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

            scalemodel.OwnerId = user.Id;

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<AddPurchasedScalemodelBindingModel, AvailableScalemodel>();
            //    cfg.CreateMap<Manifacturer, Manifacturer>();
            //});
            //config.AssertConfigurationIsValid();

            //var mapper = config.CreateMapper();
            //var dest = mapper.Map<AddPurchasedScalemodelBindingModel, AvailableScalemodel>(manifacturer);
            
            var model = this.Mapper.Map<AvailableScalemodel>(scalemodel);
            model.Manifacturer = manifacturer;
            user.PurchasedModels.Add(model);
            await this.DbContext.SaveChangesAsync();
        }
    }
}
