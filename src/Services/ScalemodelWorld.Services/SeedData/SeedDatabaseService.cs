using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Scalemodel.Data.Models;
using Scalemodel.Data.Models.JunctionClasses;
using Scalemodel.Data.Models.Scalemodels;
using ScalemodelWorld.Common.Scalemodels.BindingModels;
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

        public async Task StartSeedingStartedAsync(string userId, string path)
        {
            var jsonString = File.ReadAllText($@"{path}\Started.json");
            var deserializedStarted = JsonConvert.DeserializeObject<StartedScalemodelDto[]>(jsonString,
                new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

            var allStarted = this.Mapper.Map<IEnumerable<StartedScalemodel>>(deserializedStarted);

            foreach (var started in allStarted)
            {
                started.OwnerId = userId;
            }

            await DbContext.StartedScalemodels.AddRangeAsync(allStarted);
            await this.DbContext.SaveChangesAsync();
        }

        public async Task StartSeedingCompletedAsync(string userId, string path)
        {
            var jsonString = File.ReadAllText($@"{path}\Completed.json");
            var deserializedCompleted = JsonConvert.DeserializeObject<CompletedScalemodelDto[]>(jsonString,
                new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

            var allCompleted = this.Mapper.Map<IEnumerable<CompletedScalemodel>>(deserializedCompleted);

            foreach (var completed in allCompleted)
            {
                completed.OwnerId = userId;
            }

            await DbContext.CompletedScalemodels.AddRangeAsync(allCompleted);
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

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}