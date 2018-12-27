using System;
using System.Collections.Generic;
using Scalemodel.Data.Models.Abstractions;
using Scalemodel.Data.Models.JunctionClasses;

namespace Scalemodel.Data.Models
{
    public class Club : BaseId
    {
        public Club()
        {
            this.Members = new List<ScalemodelWorldUser>();
            this.ModelShowParticipations = new List<ClubModelshow>();
        }

        public string Name { get; set; }

        public DateTime FoundationDate { get; set; }

        public string FoundationPlace { get; set; }

        public ICollection<ScalemodelWorldUser> Members { get; set; }

        public ICollection<ClubModelshow> ModelShowParticipations { get; set; }
    }
}
