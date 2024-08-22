using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.DiscountOfferDtos;
using MultiShop.WebUI.Services.Abstracts;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _HomeDiscountOfferComponentPartial : ViewComponent
    {
        private readonly IServiceManager _manager;

        public _HomeDiscountOfferComponentPartial(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ResultDiscountOfferDto> values = await _manager.DiscountOfferService.GetAllDiscountOffersAsync();

            var random = new Random();
            var result = values.OrderBy(x => random.Next()).Take(2).ToList();

            return View(result);

        }
    }
}
