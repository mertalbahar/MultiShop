using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos;
using MultiShop.WebUI.Services.Abstracts;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IIdentityService _identityService;

        public UserController(IServiceManager manager, IHttpClientFactory httpClientFactory, IIdentityService identityService)
        {
            _manager = manager;
            _httpClientFactory = httpClientFactory;
            _identityService = identityService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            UserDetailDto values = await _manager.UserService.GetUserDetailAsync();

            return View(values);
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(UserRegisterDto userRegisterDto)
        {
            if (userRegisterDto.Password.Equals(userRegisterDto.ConfirmPassword))
            {
                HttpClient client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(userRegisterDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://localhost:5001/api/Users/register", stringContent);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("LoginUser", "User");
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult LoginUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUser(UserLoginDto userLoginDto)
        {
            await _identityService.SignIn(userLoginDto);

            return RedirectToAction("Index", "User");
        }
    }
}
