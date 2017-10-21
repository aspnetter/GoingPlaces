using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using Web.ViewModels.Authentication;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;
        public AccountController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            var result = await _authService.PasswordSignInAsync(viewModel.LoginEmail, viewModel.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return View();
            }

            return Redirect("~/");
        }

        public async Task<IActionResult> SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel signupUser)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _authService.SignOutAsync();

            return Redirect("~/");
        }
    }
}
