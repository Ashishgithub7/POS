using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using POS.Business.Services.User;
using POS.Common.DTO.User;
using POS.Common.Enums;
using POS.Data.Entities.Login;

namespace POS.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserService _userService;

        public AccountController(SignInManager<AppUser> signInManager, IUserService userService)
        {
            _signInManager = signInManager;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, string returnUrl = null)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View();

        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(UserCreateDto request)
        {
            //string baseURL = $"{Request.Scheme}://{Request.Host.Value}";
            //request.BaseUrl = baseURL;

            var result = await _userService.SaveAsync(request);

            if (result.Status == Status.Success)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        //[HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
