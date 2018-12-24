namespace Scalemodels.Models.Contracts
{
    public interface IBaseModel : IBase
    {
        int Scale { get; set; }
        string Name { get; set; }
        int Number { get; set; }
        string CombinesWith { get; set; }
        string BestCompanyOffer { get; set; }
        string InfoHowTo { get; set; }
        decimal Price { get; set; }
        string Comments { get; set; }
    }
}