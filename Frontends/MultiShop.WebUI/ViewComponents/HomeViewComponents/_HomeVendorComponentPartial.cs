using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.Abstracts;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _HomeVendorComponentPartial : ViewComponent
    {
        private readonly IServiceManager _manager;

        public _HomeVendorComponentPartial(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ResultBrandDto> values = await _manager.BrandService.GetAllBrandsAsync();

            return View(values);
        }
    }
}
