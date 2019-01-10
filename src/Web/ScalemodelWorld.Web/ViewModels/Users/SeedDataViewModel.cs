using System.ComponentModel.DataAnnotations;
using ScalemodelWorld.Common.Constants;

namespace ScalemodelWorld.Web.ViewModels.Users
{
    public class SeedDataViewModel
    {
        [Display(Name = AttributeDisplayNameConstants.PathToJSONFile)]
        public string PathToJSONFile { get; set; }
    }
}
