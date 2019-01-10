using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
using ScalemodelWorld.Data;
using ScalemodelWorld.Services.SeedData.Contracts;
using ScalemodelWorld.Services.SeedData.Dto;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace ScalemodelWorld.Services.SeedData
{
    public class SeedDatabaseService : BaseService, ISeedDatabaseService
    {
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

        public async Task StartSeedingPurchasedAsync(string userId, string path)

        {
             var jsonString = File.ReadAllText($@"{path}\Purchased.json");
            var deserializedPurchased = JsonConvert.DeserializeObject<PurchasedScalemodelDto[]>(jsonString,
                new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

            var allPurchased = this.Mapper.Map<IEnumerable<AvailableScalemodel>>(deserializedPurchased);

            foreach (var purchased in allPurchased)
            {
                purchased.OwnerId = userId;
            }

            await DbContext.AvailableScalemodels.AddRangeAsync(allPurchased);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task StartSeedingWishlistAsync(string userId, string path)

        {
            var deserializedWishList = JsonConvert.DeserializeObject<WishlistBindingModel[]>(
                File.ReadAllText($@"{path}\Wishlist.json"));

            var allWishlist = this.Mapper.Map<IEnumerable<WishScalemodel>>(deserializedWishList);

            foreach (var wishlist in allWishlist)
            {
                wishlist.UserId = userId;
            }

            await DbContext.WishScalemodels.AddRangeAsync(allWishlist);

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

        public Task StartSeedingStartedAsync(string userId, string path)
        {
            throw new NotImplementedException();
        }

        public Task StartSeedingCompletedAsync(string userId, string path)
        {
            throw new NotImplementedException();
        }
    }
}