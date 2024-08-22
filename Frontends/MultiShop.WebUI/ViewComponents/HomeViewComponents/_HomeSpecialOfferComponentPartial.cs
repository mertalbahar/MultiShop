using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.Abstracts;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _HomeSpecialOfferComponentPartial : ViewComponent
    {
        private readonly IServiceManager _manager;

        public _HomeSpecialOfferComponentPartial(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ResultSpecialOfferDto> values = await _manager.SpecialOfferService.GetAllSpecialOffersAsync();

            var random = new Random();
            var result = values.OrderBy(x => random.Next()).Take(2).ToList();

            return View(result);

        }
    }
}
