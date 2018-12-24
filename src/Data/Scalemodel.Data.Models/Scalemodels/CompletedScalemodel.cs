using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Scalemodels.Models.Abstractions;
using Scalemodels.Models.JunctionClasses;

namespace Scalemodels.Models.Scalemodels
{
    public class CompletedScalemodel : MyModel
    {
        public CompletedScalemodel()
        {
            this.Aftermarkets = new HashSet<CompletedAftermarket>();
            this.ModelShowsParticipatedIn = new HashSet<CompletedScalemodelShowParticipation>();
        }

        public string GivenSold { get; set; }

        public string PicturesLink { get; set; }

        public string ForumsLink { get; set; }

        [Required]
        public DateTime? StartingDate { get; set; }

        [Required]
        public DateTime? FinishingDate { get; set; }

        public ICollection<CompletedAftermarket> Aftermarkets { get; set; }

        public ICollection<CompletedScalemodelShowParticipation> ModelShowsParticipatedIn { get; set; }

        //TODO: UsedAftermarket
        //public ICollection<CompletedAftermarket> UsedAftermarket { get; set; }
    }
}