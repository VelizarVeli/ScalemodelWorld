using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Scalemodel.Data.Models;
using Scalemodel.Data.Models.Scalemodels;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services.SeedData.Contracts;
using ScalemodelWorld.Services.SeedData.Dto;

namespace ScalemodelWorld.Services.SeedData
{
    public class SeedDatabaseService : BaseService, ISeedDatabaseService
    {
        private readonly ScalemodelWorldContext db;
        //private readonly UserManager<ScalemodelWorldUser> _userManager;

      
        public SeedDatabaseService(ScalemodelWorldContext dbContext,
            IMapper mapper,
            UserManager<ScalemodelWorldUser> userManager)
            : base(dbContext, mapper, userManager)
        {
        }


        //private async Task<ScalemodelWorldUser> GetUserByNameAsync(string name)
        //{
        //    var user = await this._userManager.FindByNameAsync(name);
        //    return user;
        //}

        public static void ImportWishList(ScalemodelWorldContext context, string jsonString)
        {
            var deserializedWishList = JsonConvert.DeserializeObject<WishListDto[]>(jsonString);

            var validWishListItems = new HashSet<WishScalemodel>();

            foreach (var wishListDto in deserializedWishList)
            {

                var wishList = new WishScalemodel
                {
                    Name = wishListDto.Name,
                    Manifacturer = wishListDto.Manifacturer,
                    FactoryNumber = wishListDto.FactoryNumber,
                };

                validWishListItems.Add(wishList);
            }

            context.WishScalemodels.AddRange(validWishListItems);
            context.SaveChanges();
        }
    }
}