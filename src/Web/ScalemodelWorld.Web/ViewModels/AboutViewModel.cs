﻿using System;

namespace ScalemodelWorld.Web.ViewModels
{
    public class AboutViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CurrentDate { get; set; } = DateTime.UtcNow;
    }
}
