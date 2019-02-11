using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Scalemodel.Data.Models.Enums
{
    public enum Category
    {
        [Display(Name= "Propeller Driven Aircrafts")]
        PropellerDrivenAircrafts = 1,
        [Display(Name = "Jet Aircrafts")]
        JetAircrafts = 2,
        [Display(Name = "Jet Aircrafts")]

        CivilAirplanes = 3,
        Helicopters = 4,
        WheeledMilitaryVehicles = 5,
        TrackedMilitaryVehicles = 6,
        Artillery = 7,
        Diorama = 8,
        Figures = 9,
        CarsTrucksMotocycles = 10,
        SailingShips = 11,
        Submarines = 12,
        SciFiSpace = 13,
        Architecture = 14,
        ScratchBuild = 15
    }
}