using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using Web.ViewModels.Authentication;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var result = await _accountService.PasswordSignInAsync(loginModel.LoginEmail, loginModel.Password, loginModel.RememberMe);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return View();
            }

            return Redirect("~/");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _accountService.SignOutAsync();

            return Redirect("~/");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel signupUser)
        {
            var userCreateResult = IdentityResult.Success;

            if (ModelState.IsValid)
            {
                userCreateResult = await _accountService.SignUp(
                    signupUser.LoginEmail,
                    signupUser.FirstName,
                    signupUser.LastName,
                    signupUser.Password);
            }

            if (!userCreateResult.Succeeded)
            {
                ModelState.AddModelError(
                    string.Empty,
                    string.Join(". ", userCreateResult.Errors.Select(error => error.Description)));
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            TempData["FlashMessage"] = $"User '{signupUser.LoginEmail}' created successfully! You can now log in.";

            return RedirectToAction("Login");
        }
    }
}
