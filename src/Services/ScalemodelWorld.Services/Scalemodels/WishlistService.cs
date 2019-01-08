using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Scalemodel.Data.Models;
using Scalemodel.Data.Models.Scalemodels;
using ScalemodelWorld.Common;
using ScalemodelWorld.Common.Constants;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services.Scalemodels.Contracts;

namespace ScalemodelWorld.Services.Scalemodels
{
    public class WishlistService : BaseService, IWishlistService
    {
        public WishlistService(ScalemodelWorldContext dbContext,
            IMapper mapper,
            UserManager<ScalemodelWorldUser> userManager)
            : base(dbContext, mapper, userManager)
        {
        }

        public async Task AddWishAsync(WishlistScalemodelBindingModel scalemodel, string id)
        {
            var user = await this.UserManager.FindByIdAsync(id);

            CoreValidator.ThrowIfNull(scalemodel);

            scalemodel.UserId = user.Id;

            var model = this.Mapper.Map<WishScalemodel>(scalemodel);
            var biggestNumber = DbContext.WishScalemodels.Where(a => a.UserId == scalemodel.UserId).OrderByDescending(u => u.Number)
                .FirstOrDefault();
            model.Number = biggestNumber == null ? NumberConstants.StartNumberInScalemodels : biggestNumber.Number + 1;
            user.WishList.Add(model);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<WishlistScalemodelBindingModel>> WishlistAll(string userId)
        {
            var user = await this.UserManager.FindByIdAsync(userId);

            var allWishlist = this.Mapper.Map<IEnumerable<WishlistScalemodelBindingModel>>(
                this.DbContext.WishScalemodels.Where(i => i.UserId == user.Id));



            return allWishlist;
        }

        //private async Task updateNumbers(int oldNumberValue, int editedNumber)
        //{
        //    var availableModels = DbContext.AvailableScalemodels.AddRangeAsync()

        //    if (oldNumberValue > editedNumber)
        //    {
        //        for (int i = editedNumber; i < oldNumberValue; i++)
        //        {
        //            DbContext
        //        }
        //    }

        //    DbContext.SaveChangesAsync();
        //}
    }
}
