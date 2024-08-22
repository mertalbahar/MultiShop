using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.Abstracts;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _HomeCarouselComponentPartial : ViewComponent
    {
        private readonly IServiceManager _manager;

        public _HomeCarouselComponentPartial(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ResultFeatureSliderDto> values = await _manager.FeatureSliderService.GetAllFeatureSlidersAsync();

            return View(values);
        }
    }
}
