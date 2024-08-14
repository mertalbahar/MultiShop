using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
	public class UserController : Controller
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
		{
			return View();
		}

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(UserRegisterDto userRegisterDto)
        {
            if (userRegisterDto.Password.Equals(userRegisterDto.ConfirmPassword))
            {
                HttpClient client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(userRegisterDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://localhost:5001/api/Registers", stringContent);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
                return View();
        }
	}
}
