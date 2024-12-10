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
            long brandCount = await _manager.CatalogStatisticServices.GetBrandCount();
            long categoryCount = await _manager.CatalogStatisticServices.GetCategoryCount();
            long productCount = await _manager.CatalogStatisticServices.GetProductCount();
            decimal productAvgPrice = await _manager.CatalogStatisticServices.GetProductAvgPrice();
            string maxPriceProductName = await _manager.CatalogStatisticServices.GetMaxPriceProductName();
            string minPriceProductName = await _manager.CatalogStatisticServices.GetMinPriceProductName();

            CatalogStatisticViewModel catalogStatistics = new CatalogStatisticViewModel
            {
                BrandCount = brandCount,
                CategoryCount = categoryCount,
                ProductCount = productCount,
                ProductAvgPrice = productAvgPrice,
                MaxPriceProductName = maxPriceProductName,
                MinPriceProductName = minPriceProductName
            };

            int userCount = await _manager.UserStatisticService.GetUserCountAsync();

            UserStatisticViewModel userStatistics = new UserStatisticViewModel
            {
                UserCount = userCount
            };

            int activeCommentCount = await _manager.CommentStatisticService.GetActiveCommentCountAsync();
            int passiveCommentCount = await _manager.CommentStatisticService.GetPassiveCommentCountAsync();
            int totalCommentCount = await _manager.CommentStatisticService.GetTotalCommentCountAsync();

            CommentStatisticViewModel commentStatistics = new CommentStatisticViewModel
            {
                ActiveCommentCount = activeCommentCount,
                PassiveCommentCount = passiveCommentCount,
                TotalCommentCount = totalCommentCount
            };

            int discountCouponCount = await _manager.DiscountStatisticService.GetDiscountCouponCountAsync();

            DiscountStatisticViewModel discountStatistics = new DiscountStatisticViewModel
            {
                DiscountCouponCount = discountCouponCount
            };

            StatisticViewModel statisticViewModel = new StatisticViewModel
            {
                CatalogStatistics = catalogStatistics,
                UserStatistics = userStatistics,
                CommentStatistics = commentStatistics,
                DiscountStatistics = discountStatistics
            };

            return View(statisticViewModel);
        }
    }
}
