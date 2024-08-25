using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CommentDtos.UserCommentDtos;
using MultiShop.WebUI.Services.Abstracts;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserCommentController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IMapper _mapper;

        public UserCommentController(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<ResultUserCommentDto> values = await _manager.UserCommentService.GetAllUserCommentsAsync();

            return View(values);
        }

        private async Task<SelectList> GetProductsSelectList()
        {
            List<ResultProductDto> values = await _manager.ProductService.GetAllProductsAsync();

            List<SelectListItem> productValues = (from x in values
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.Id
                                                  }).ToList();

            return new SelectList(productValues, "Value", "Text");
        }

        public async Task<IActionResult> DeleteUserComment([FromRoute(Name = "id")] int id)
        {
            await _manager.UserCommentService.DeleteUserCommentAsync(id);

            return RedirectToAction("Index", "UserComment", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUserComment([FromRoute(Name = "id")] int id)
        {
            GetByIdUserCommentDto values = await _manager.UserCommentService.GetUserCommentByIdAsync(id);
            UpdateUserCommentDto result = _mapper.Map<UpdateUserCommentDto>(values);

            ViewBag.Products = await GetProductsSelectList();

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUserComment([FromForm] UpdateUserCommentDto updateUserCommentDto)
        {
            await _manager.UserCommentService.UpdateUserCommentAsync(updateUserCommentDto);

            return RedirectToAction("Index", "UserComment", new { area = "Admin" });
        }
    }
}
