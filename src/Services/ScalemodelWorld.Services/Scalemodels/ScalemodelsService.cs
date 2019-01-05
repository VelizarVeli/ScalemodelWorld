using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalemodel.Data.Models;
using Scalemodel.Data.Models.Scalemodels;
using ScalemodelWorld.Common;
using ScalemodelWorld.Common.Constants;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Common.Scalemodels.ViewModels;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services.Scalemodels.Contracts;

namespace ScalemodelWorld.Services.Scalemodels
{
    public class ScalemodelsService : BaseService, IScalemodelsService
    {
        public ScalemodelsService(ScalemodelWorldContext dbContext,
            IMapper mapper,
            UserManager<ScalemodelWorldUser> userManager)
            : base(dbContext, mapper, userManager)
        {
        }

        public async Task AddScalemodelAsync(AvailableScalemodelBindingModel scalemodel, string id)
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

            var model = this.Mapper.Map<AvailableScalemodel>(scalemodel);
            model.Manifacturer = manifacturer;
            var biggestNumber = DbContext.AvailableScalemodels.Where(a => a.OwnerId == scalemodel.OwnerId).OrderByDescending(u => u.Number)
                .FirstOrDefault();
            model.Number = biggestNumber == null ? NumberConstants.StartNumberInScalemodels : biggestNumber.Number + 1;
            user.PurchasedModels.Add(model);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AvailableAllViewModel>> AvailableAll(string id)
        {
            var user = await this.UserManager.FindByIdAsync(id);

            var allAvailable = this.Mapper.Map<IEnumerable<AvailableAllViewModel>>(
                this.DbContext.AvailableScalemodels.Where(i => i.OwnerId == user.Id));

            return allAvailable;
        }

        public async Task<AvailableScalemodelBindingModel> GetAvailableScalemodelDetailsAsync(int id, string userId)
        {
            var user = await this.GetUserByIdAsync(userId);
            var availableModel = await this.DbContext.AvailableScalemodels.FirstOrDefaultAsync(e => e.Id == id && e.OwnerId == user.Id);
            var scalemodel = this.Mapper.Map<AvailableScalemodelBindingModel>(availableModel);
            scalemodel.Manifacturer = this.DbContext.Manifacturers.FirstOrDefault(mi => mi.Id == availableModel.ManifacturerId).Name;

            return scalemodel;
        }

        public async Task<IEnumerable<AllModelsViewModel>> StartedAll(string id)
        {
            var user = await this.UserManager.FindByIdAsync(id);

            var allstarted = this.Mapper.Map<IEnumerable<AllModelsViewModel>>(
                this.DbContext.StartedScalemodels.Where(i => i.OwnerId == user.Id));

            return allstarted;
        }
    }
}
