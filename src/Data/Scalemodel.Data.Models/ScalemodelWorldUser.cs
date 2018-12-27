using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Scalemodel.Data.Models.JunctionClasses;

namespace Scalemodel.Data.Models
{
    // Add profile data for application users by adding properties to the ScalemodelWorldUser class
    public class ScalemodelWorldUser : IdentityUser
    {
        public ScalemodelWorldUser()
        {
            this.ModelshowParticipations = new List<UserModelshow>();
        }

        public int? ClubId { get; set; }
        public Club ClubMembership { get; set; }

        public ICollection<UserModelshow> ModelshowParticipations { get; set; }
    }
}
