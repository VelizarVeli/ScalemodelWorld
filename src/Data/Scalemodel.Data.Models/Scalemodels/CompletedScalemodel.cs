﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Scalemodel.Data.Models.Abstractions;
using Scalemodel.Data.Models.JunctionClasses;

namespace Scalemodel.Data.Models.Scalemodels
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

        public string OwnerId { get; set; }
        public ScalemodelWorldUser Owner { get; set; }
    }
}