using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using VsunPharmaWebsite.IRepository;
using VsunPharmaWebsite.Models;

namespace VsunPharmaWebsite.Controllers
{
    public class HomeController : Controller
    {
		private readonly IHomeRepository _homeRepository;

		public HomeController(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Products()
		{
			return View();
		}

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> GetProductCategory()
        {
            var data = _homeRepository.GetProductCategory();
            return Json(new {Records = data});
        }

        public async Task<IActionResult> GetAllProducts()
        {
            var data = _homeRepository.GetAllProducts();
            return Json(new { Records = data });
        }

        [HttpPost("/Home/Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            UsersModel res = _homeRepository.LoginUser(model);

            if(res.Email == model.EmailID && res.Password == model.Password)
            {
                var claims = new List<Claim>
                                {
                                    new Claim(ClaimTypes.Name, res.Name),
                                    new Claim(ClaimTypes.Role, res.Role),
                                    new Claim(ClaimTypes.Email, res.Email),
                                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties { ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(120) };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost("/Home/Register")]
        public async Task<IActionResult> Register(UsersModel model)
        {
            _homeRepository.RegisterUser(model);

            return RedirectToAction("Index", "Home");
        }
    }
}
