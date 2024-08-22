using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.Abstracts;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.HomeViewComponents
{
    public class _HomeAboutComponentPartial : ViewComponent
    {
        private readonly IServiceManager _manager;

        public _HomeAboutComponentPartial(IServiceManager manager)
        {
            _manager = manager;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ResultAboutDto> values = await _manager.AboutService.GetAllAboutsAsync();

            var result = values.LastOrDefault();

            return View(result);
        }
    }
}
