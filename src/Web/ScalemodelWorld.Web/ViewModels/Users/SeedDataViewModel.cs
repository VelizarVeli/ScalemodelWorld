using System.ComponentModel.DataAnnotations;
using ScalemodelWorld.Common.Constants;
using ScalemodelWorld.Web.ViewModels.Users.Enums;

namespace ScalemodelWorld.Web.ViewModels.Users
{
    public class SeedDataViewModel
    {
        [Display(Name = AttributeDisplayNameConstants.PathToJSONFile)]
        public string PathToJSONFile { get; set; }

        public Category Category { get; set; }
    }
}
