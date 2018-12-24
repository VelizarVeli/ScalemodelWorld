using System;
using System.Collections.Generic;
using Scalemodels.Models.Abstractions;
using Scalemodels.Models.JunctionClasses;

namespace Scalemodels.Models.Modelshows
{
    public class ModelShow : BaseModel
    {
        public ModelShow()
        {
            this.Participants = new HashSet<CompletedScalemodelShowParticipation>();
            this.Categories = new HashSet<ModelShowCategory>();
        }

        public string ModelShowName { get; set; }

        public DateTime Year { get; set; }

        public string Place { get; set; }

        public ICollection<CompletedScalemodelShowParticipation> Participants { get; set; }

        public ICollection<ModelShowCategory> Categories { get; set; }
    }
}
