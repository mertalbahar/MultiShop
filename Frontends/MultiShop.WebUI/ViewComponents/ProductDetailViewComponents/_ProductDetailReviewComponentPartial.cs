using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos.UserCommentDtos;
using MultiShop.WebUI.Services.Abstracts;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        private readonly IServiceManager _manager;

        public _ProductDetailReviewComponentPartial(IServiceManager manager)
        {
            _manager = manager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            List<ResultUserCommentDto> values = await _manager.UserCommentService.GetyUserCommentByProductIdAsync(id);

            return View(values);
        }
    }
}
