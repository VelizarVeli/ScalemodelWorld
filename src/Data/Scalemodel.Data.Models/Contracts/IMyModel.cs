using System;

namespace Scalemodel.Data.Models.Contracts
{
    public interface IMyModel
    {
        DateTime DateOfPurchase { get; set; }
        string Place { get; set; }
    }
}