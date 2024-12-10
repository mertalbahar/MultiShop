namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public interface ICatalogStatisticService
    {
        Task<long> GetCategoryCount();
        Task<long> GetProductCount();
        Task<decimal> GetProductAvgPrice();
        Task<long> GetBrandCount();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();
    }
}
