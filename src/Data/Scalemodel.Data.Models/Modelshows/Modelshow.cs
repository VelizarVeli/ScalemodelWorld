using System;
using System.Collections.Generic;
using Scalemodel.Data.Models.Abstractions;
using Scalemodel.Data.Models.JunctionClasses;

namespace Scalemodel.Data.Models.Modelshows
{
    public class ModelShow : BaseModel
    {
        public ModelShow()
        {
            this.ScalemodelsParticipated = new HashSet<CompletedScalemodelShowParticipation>();
            this.Categories = new HashSet<ModelShowCategory>();
            this.ClubsParticipated = new List<ClubModelshow>();
            this.Participants = new List<UserModelshow>();
        }

        public string ModelShowName { get; set; }

        public DateTime Year { get; set; }

        public string Place { get; set; }

        public ICollection<CompletedScalemodelShowParticipation> ScalemodelsParticipated { get; set; }

        public ICollection<ModelShowCategory> Categories { get; set; }

        public ICollection<ClubModelshow> ClubsParticipated { get; set; }

        public ICollection<UserModelshow> Participants { get; set; }
    }
}
