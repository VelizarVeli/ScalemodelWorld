using System;

namespace Scalemodels.Models.Contracts
{
    public interface IMyModel
    {
        DateTime DateOfPurchase { get; set; }
        string Place { get; set; }
    }
}