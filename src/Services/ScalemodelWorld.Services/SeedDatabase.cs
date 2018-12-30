using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Scalemodel.Data.Models;
using Scalemodel.Data.Models.Scalemodels;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services.Dto;

namespace ScalemodelWorld.Services
{
    public class SeedDatabase
    {
        private readonly ScalemodelWorldContext db;
        //private readonly UserManager<ScalemodelWorldUser> _userManager;

        public SeedDatabase(ScalemodelWorldContext db/*, UserManager<ScalemodelWorldUser> userManager*/)
        {
            this.db = db;
            //this._userManager = userManager;
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
                var manifacturer = context.Manifacturers.FirstOrDefault(m => m.Name == wishListDto.Manifacturer);

                if (manifacturer == null)
                {
                    manifacturer = new Manifacturer
                    {
                        Name = wishListDto.Manifacturer
                    };
                    context.Manifacturers.Add(manifacturer);
                    context.SaveChanges();
                }

                var wishList = new WishScalemodel
                {
                    Name = wishListDto.Name,
                    Manifacturer = manifacturer,
                    FactoryNumber = wishListDto.FactoryNumber,
                };

                validWishListItems.Add(wishList);
            }

            context.WishScalemodels.AddRange(validWishListItems);
            context.SaveChanges();
        }
    }
}