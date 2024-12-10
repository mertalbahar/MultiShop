namespace MultiShop.Catalog.WebApi.Services.StatisticServices
{
    public interface IStatisticService
    {
        Task<long> GetCategoryCount();
        Task<long> GetProductCount();
        Task<decimal> GetProductAvgPrice();
        Task<long> GetBrandCount();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();
    }
}
