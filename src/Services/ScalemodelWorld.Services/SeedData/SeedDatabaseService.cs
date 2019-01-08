using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Scalemodel.Data.Models;
using Scalemodel.Data.Models.JunctionClasses;
using Scalemodel.Data.Models.Scalemodels;
using ScalemodelWorld.Common;
using ScalemodelWorld.Common.Constants;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
using ScalemodelWorld.Data;
using ScalemodelWorld.Services.SeedData.Contracts;
using ScalemodelWorld.Services.SeedData.Dto;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace ScalemodelWorld.Services.SeedData
{
    public class SeedDatabaseService : BaseService, ISeedDatabaseService
    {
        private readonly ScalemodelWorldContext db;


        public SeedDatabaseService(ScalemodelWorldContext context,
            IMapper mapper,
            UserManager<ScalemodelWorldUser> userManager)
            : base(context, mapper, userManager)
        {
        }

        public static void ImportWishList(ScalemodelWorldContext context, string jsonString)
        {
            var deserializedWishList = JsonConvert.DeserializeObject<WishlistBindingModel[]>(jsonString);

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

        //public async Task StartSeedingAsync(string id)
        //{
        //    var user = await this.UserManager.FindByIdAsync(id);

        //    var deserializedWishList = JsonConvert.DeserializeObject<WishlistBindingModel[]>(
        //        File.ReadAllText(@"C:\Users\Google\Documents\Proj\ScalemodelWorld\src\Data\ScalemodelWorld.Data\Datasets\Wishlist.json"));


        //    var allWishlist = this.Mapper.Map<IEnumerable<WishlistBindingModel>>(deserializedWishList);

        //var validWishListItems = new HashSet<WishScalemodel>();

        //foreach (var wishListDto in deserializedWishList)
        //{

        //    var wishList = new WishScalemodel()
        //    {
        //        Name = wishListDto.Name,
        //        Manifacturer = wishListDto.Manifacturer,
        //        FactoryNumber = wishListDto.FactoryNumber,
        //        BestCompanyOffer = "Besty",
        //        BoxPicture = wishListDto.BoxPicture,
        //        CombinesWith = "Combaina",
        //        Comments = "Best comments",
        //        Number = wishListDto.Number,
        //        InfoHowTo = "link",
        //        Price = 12.2M,
        //        LinkToScalemates = wishListDto.LinkToScalemates,
        //        UserId = user.Id,
        //        User = user,
        //        Scale = wishListDto.Scale

        //    };

        //    //var wishList = Mapper.Map<WishScalemodel>(wishListDto);
        //    //wishList.UserId = userId;
        //    //wishList.Price = 0;
        //    validWishListItems.Add(wishList);
        //    //wishList.User = user;
        //    db.WishScalemodels.Add(wishList);
        //    await this.db.SaveChangesAsync();
        //}

        //await db.WishScalemodels.AddRangeAsync(allWishlist);
        //await this.db.SaveChangesAsync();
        //}

        public async Task<IEnumerable<WishlistScalemodelBindingModel>> WishlistAll(string userId)
        {
            var user = await this.UserManager.FindByIdAsync(userId);

            var allWishlist = this.Mapper.Map<IEnumerable<WishlistScalemodelBindingModel>>(
                this.DbContext.WishScalemodels.Where(i => i.UserId == user.Id));

            return allWishlist;
        }

        public async Task StartSeedingAsync(string id)
        {


            var deserializedWishList = JsonConvert.DeserializeObject<WishlistBindingModel[]>(
                File.ReadAllText(@"C:\Users\Google\Documents\Proj\ScalemodelWorld\src\Data\ScalemodelWorld.Data\Datasets\Wishlist.json"));

            var user = await this.UserManager.FindByIdAsync(id);

            var scalemodel = deserializedWishList[1];

            scalemodel.UserId = user.Id;

            foreach (var scaleModel in deserializedWishList)
            {
              var currentModel =  this.Mapper.Map<WishScalemodel>(scaleModel);
                user.WishList.Add(currentModel);

            }
            await this.DbContext.SaveChangesAsync();
        }

        public static string ImportCompleteAftermarketConnections(ScalemodelWorldContext context, string jsonString)
        {
            var deserializedConnections = JsonConvert.DeserializeObject<ConnectionDto[]>(jsonString);

            var validConnections = new List<CompletedAftermarket>();

            foreach (var connectionDto in deserializedConnections)
            {
                var connection = new CompletedAftermarket()
                {
                    //CompletedModelId = 2,
                    //UsedAftermarketId = 99
                };

                validConnections.Add(connection);
            }

            context.CompletedAftermarkets.AddRange(validConnections);
            context.SaveChanges();
            return "All good";
        }

        //public static string ImportAftermarket(ScalemodelWorldContext context, string jsonString)
        //{
        //    //TODO: Connect and fill the data between many-to-many
        //    var deserializedAftermarket = JsonConvert.DeserializeObject<PurchasedAftermarketDto[]>(jsonString,
        //        new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });

        //    var validAftermarketItems = new List<Aftermarket>();

        //    //TODO: Connect with Completed models after seeding Completed

        //    foreach (var aftermarketDto in deserializedAftermarket)
        //    {
        //        if (!IsValid(aftermarketDto))
        //        {
        //            continue;
        //        }

        //        var manifacturer = context.Manifacturers
        //            .FirstOrDefault(m => m.Name == aftermarketDto.Manifacturer);

        //        if (manifacturer == null)
        //        {
        //            manifacturer = new Manifacturer
        //            {
        //                Name = aftermarketDto.Manifacturer
        //            };
        //            context.Manifacturers.Add(manifacturer);
        //            context.SaveChanges();
        //        }

        //        var aftermarket = new Aftermarket
        //        {
        //            ProductName = aftermarketDto.ProductName,
        //            Manifacturer = manifacturer,
        //            Price = aftermarketDto.Price,
        //            Category = aftermarketDto.Category,
        //            DateOfPurchase = aftermarketDto.DateOfPurchase,
        //            FactoryNumber = aftermarketDto.FactoryNumber,
        //            Placement = aftermarketDto.Placement
        //        };
        //        validAftermarketItems.Add(aftermarket);
        //        context.Aftermarkets.Add(aftermarket);
        //        var usedInModels = new List<CompletedAftermarket>();
        //        var usedInCurrentModel = aftermarketDto.Placement.Split(';', StringSplitOptions.RemoveEmptyEntries);

        //        foreach (var completedId in usedInCurrentModel)
        //        {
        //            var usedInCompletedModel = int.TryParse(completedId, out int completedModelNumber);
        //            if (usedInCompletedModel)
        //            {
        //                var model = context.Completed.FirstOrDefault(n => n.Number == completedModelNumber);
        //                var modelsId = new CompletedAftermarket
        //                {
        //                    CompletedModelId = model.Id
        //                };

        //                aftermarket.CompletedModels = usedInModels;
        //                usedInModels.Add(modelsId);
        //            }
        //        }
        //    }

        //    context.Aftermarkets.AddRange(validAftermarketItems);
        //    context.SaveChanges();

        //    return "All Good!";
        //}

        //public static string ImportCompletedModels(ScalemodelWorldContext context, string jsonString)
        //{
        //    var deserializedCompletedModels = JsonConvert.DeserializeObject<CompletedDto[]>(jsonString,
        //        new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });

        //    var validCompletedModels = new List<CompletedAftermarket>();

        //    foreach (var completedModelDto in deserializedCompletedModels)
        //    {
        //        if (!IsValid(completedModelDto))
        //        {
        //            continue;
        //        }

        //        var manifacturer = context.Manifacturers
        //            .FirstOrDefault(m => m.Name == completedModelDto.Manifacturer);

        //        DateTime? dateOfPurchase = null;
        //        if (!string.IsNullOrWhiteSpace(completedModelDto.DateOfPurchase))
        //        {
        //            dateOfPurchase = DateTime.ParseExact(completedModelDto.DateOfPurchase, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        //        }

        //        DateTime? startedOnDate = null;
        //        if (!string.IsNullOrWhiteSpace(completedModelDto.DateOfPurchase))
        //        {
        //            startedOnDate = DateTime.ParseExact(completedModelDto.StartedOnDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        //        }

        //        DateTime? finishedOnDate = null;
        //        if (!string.IsNullOrWhiteSpace(completedModelDto.DateOfPurchase))
        //        {
        //            finishedOnDate = DateTime.ParseExact(completedModelDto.FinishedOnDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        //        }

        //        if (manifacturer == null)
        //        {
        //            manifacturer = new Manifacturer
        //            {
        //                Name = completedModelDto.Manifacturer
        //            };
        //            context.Manifacturers.Add(manifacturer);
        //            context.SaveChanges();
        //        }

        //        var completed = new CompletedScalemodel()
        //        {
        //            Number = completedModelDto.Number,
        //            Name = completedModelDto.Name,
        //            Scale = completedModelDto.Scale,
        //            Manifacturer = manifacturer,
        //            FactoryNumber = completedModelDto.FactoryNumber,
        //            Price = completedModelDto.Price,
        //            Placement = completedModelDto.Placement,
        //            BestCompanyOffer = completedModelDto.BestCompanyOffer,
        //            PicturesLink = completedModelDto.PicturesLink,
        //            ForumsLink = completedModelDto.ForumsLink,
        //            GivenSold = completedModelDto.GivenSold,
        //            CombinesWith = completedModelDto.CombinesWith,
        //            DateOfPurchase = dateOfPurchase,
        //            StartedOnDate = startedOnDate,
        //            FinishedOnDate = finishedOnDate
        //        };

        //        validCompletedModels.Add(completed);
        //    }

        //    context.CompletedScalemodels.AddRange(validCompletedModels);
        //    context.SaveChanges();

        //    return "All Good!";
        //}
        
        //public static string ImportTools(ScalemodelWorldContext context, string jsonString)
        //{
        //    var deserializedTools = JsonConvert.DeserializeObject<ToolDto[]>(jsonString,
        //        new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });

        //    var validTools = new HashSet<Tool>();

        //    foreach (var toolDto in deserializedTools)
        //    {
        //        var tool = new Tool
        //        {
        //            Name = toolDto.Name,
        //            Price = toolDto.Price,
        //            DateOfPurchase = toolDto.DateOfPurchase,
        //            Description = toolDto.Description
        //        };

        //        validTools.Add(tool);
        //    }

        //    context.Tools.AddRange(validTools);
        //    context.SaveChanges();
        //    return "All good";
        //}

        //public static string ImportConsumables(ScalemodelWorldContext context, string jsonString)
        //{
        //    var deserializedPaints = JsonConvert.DeserializeObject<PaintDto[]>(jsonString);

        //    var validPaints = new HashSet<PaintAndConsumable>();

        //    foreach (var paintDto in deserializedPaints)
        //    {
        //        var manifacturer = context.Manifacturers.FirstOrDefault(m => m.Name == paintDto.Manifacturer);

        //        if (manifacturer == null)
        //        {
        //            manifacturer = new Manifacturer
        //            {
        //                Name = paintDto.Manifacturer
        //            };
        //            context.Manifacturers.Add(manifacturer);
        //            context.SaveChanges();
        //        }

        //        DateTime? dateOfPurchase = null;
        //        if (!string.IsNullOrWhiteSpace(paintDto.DateOfPurchase))
        //        {
        //            dateOfPurchase = DateTime.ParseExact(paintDto.DateOfPurchase, "dd.MM.yyyy", CultureInfo.InvariantCulture);
        //        }

        //        var paint = new PaintAndConsumable()
        //        {
        //            Name = paintDto.Name,
        //            Manifacturer = manifacturer,
        //            Price = paintDto.Price,
        //            DateOfPurchase = dateOfPurchase,
        //            ManifacturerNumber = paintDto.ManifacturerNumber,
        //            Coverage = paintDto.Coverage,
        //            Type = paintDto.Type
        //        };

        //        validPaints.Add(paint);
        //    }

        //    context.PaintsAndConsumables.AddRange(validPaints);
        //    context.SaveChanges();
        //    return "All good";
        //}

        //TODO: Import modelshows
        //public static string ImportModelShows(string jsonString)
        //{
        //    var deserializedModelShows = JsonConvert.DeserializeObject<ModelShowDto[]>(jsonString, new JsonSerializerSettings()
        //    {
        //        NullValueHandling = NullValueHandling.Ignore
        //    });

        //    var sb = new StringBuilder();

        //    var validModelShows = new List<ModelShow>();
        //    foreach (var modelShowDto in deserializedModelShows)
        //    {
        //        if (!IsValid(modelShowDto))
        //        {
        //            continue;
        //        }

        //        //    var categories = modelShowDto.Categories.Select(s => new ModelShowCategory
        //        //        {
        //        //            ModelShow = context.ModelShows.SingleOrDefault(sc => sc.Categories == s.CategoryId)
        //        //        })
        //        //        .ToArray();

        //        //    var train = new Train
        //        //    {
        //        //        TrainNumber = trainDto.TrainNumber,
        //        //        Type = type,
        //        //        TrainSeats = trainSeats
        //        //    };

        //        //    validTrains.Add(train);

        //        //    sb.AppendLine(string.Format(SuccessMessage, trainDto.TrainNumber));
        //    }

        //    //context.Trains.AddRange(validTrains);
        //    db.SaveChanges();

        //    var result = sb.ToString();
        //    return result;
        //}

        //public Task StartSeedingAsync(string userId, string path, string category)
        //{
        //    throw new System.NotImplementedException();
        //}

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }

        public Task StartSeedingAsync(string userId, string path, string category)
        {
            throw new NotImplementedException();
        }
    }
}