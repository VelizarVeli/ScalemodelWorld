using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Scalemodel.Data.Models.JunctionClasses;
using Scalemodel.Data.Models.Scalemodels;

namespace Scalemodel.Data.Models
{
    // Add profile data for application users by adding properties to the ScalemodelWorldUser class
    public class ScalemodelWorldUser : IdentityUser
    {
        public ScalemodelWorldUser()
        {
            this.ModelshowParticipations = new List<UserModelshow>();
            this.PurchasedModels = new List<AvailableScalemodel>();
            this.CompletedModels = new List<CompletedScalemodel>();
            this.StartedModels = new List<StartedScalemodel>();
            this.WishList = new List<WishScalemodel>();
            this.Aftermarket = new List<Aftermarket>();
            this.OwnedBooks = new List<Book>();
            this.Consumables = new List<Consumable>();
            this.OwnedTools = new List<Tool>();
        }

        public string Nickname { get; set; }

        public int? ClubId { get; set; }
        public Club ClubMembership { get; set; }

        public ICollection<UserModelshow> ModelshowParticipations { get; set; }

        public ICollection<AvailableScalemodel> PurchasedModels { get; set; }
        public ICollection<CompletedScalemodel> CompletedModels { get; set; }
        public ICollection<StartedScalemodel> StartedModels { get; set; }
        public ICollection<WishScalemodel> WishList { get; set; }
        public ICollection<Aftermarket> Aftermarket { get; set; }
        public ICollection<Book> OwnedBooks { get; set; }
        public ICollection<Consumable> Consumables { get; set; }
        public ICollection<Tool> OwnedTools { get; set; }
    }
}
