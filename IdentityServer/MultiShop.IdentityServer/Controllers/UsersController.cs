using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("getuserdetail")]
        public async Task<IActionResult> GetUserDetail()
        {
            var userClaim = User.Claims.FirstOrDefault(x => x.Type.Equals(JwtRegisteredClaimNames.Sub));
            ApplicationUser user = await _userManager.FindByIdAsync(userClaim.Value);

            return Ok(new
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserRegisterDto userRegisterDto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
            };
            IdentityResult result = await _userManager.CreateAsync(user, userRegisterDto.Password);

            if (result.Succeeded)
            {
                return Ok("Kullanıcı başarıyla eklendi.");
            }
            else
            {
                return BadRequest("Bir hata oluştu, tekrar deneyiniz.");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(UserLoginDto userLoginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password, false, false);

            if (result.Succeeded)
            {
                return Ok("Giriş başarılı.");
            }
            else
            {
                return BadRequest("Kullanıcı adı veya Şifre hatalı.");
            }
        }

        [HttpGet("getuserlist")]
        public async Task<IActionResult> GetAllUsers()
        {
            List<ApplicationUser> users = await _userManager.Users.ToListAsync();

            return Ok(users);
        }
    }
}
