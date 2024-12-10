using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Areas.Admin.Models;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly IServiceManager _manager;

        public StatisticController(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Index()
        {
            var brandCount = await _manager.CatalogStatisticServices.GetBrandCount();
            var categoryCount = await _manager.CatalogStatisticServices.GetCategoryCount();
            var productCount = await _manager.CatalogStatisticServices.GetProductCount();
            var productAvgPrice = await _manager.CatalogStatisticServices.GetProductAvgPrice();
            var maxPriceProductName = await _manager.CatalogStatisticServices.GetMaxPriceProductName();
            var minPriceProductName = await _manager.CatalogStatisticServices.GetMinPriceProductName();

            var catalogStatistics = new CatalogStatisticViewModel
            {
                BrandCount = brandCount,
                CategoryCount = categoryCount,
                ProductCount = productCount,
                ProductAvgPrice = productAvgPrice,
                MaxPriceProductName = maxPriceProductName,
                MinPriceProductName = minPriceProductName
            };

            var statisticViewModel = new StatisticViewModel
            {
                CatalogStatistics = catalogStatistics
            };

            return View(statisticViewModel);
        }
    }
}
