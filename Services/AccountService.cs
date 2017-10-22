using System.Threading.Tasks;
using Data.Users;
using Microsoft.AspNetCore.Identity;

namespace Services
{
    public class AccountService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountService(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<SignInResult> PasswordSignInAsync(string loginEmail, string password, bool persist)
        {
            return await _signInManager.PasswordSignInAsync(
                loginEmail,
                password,
                persist,
                lockoutOnFailure: false
            );
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> SignUp(string loginEmail, string firstName, string lastName, string password)
        {
            var createResult = await _userManager.CreateAsync(new ApplicationUser
            {
                FirstName = firstName,
                LastName = lastName,
                Email = loginEmail,
                UserName = loginEmail,
                AccessFailedCount = 0,
                LockoutEnabled = false
            }, password);

            return createResult;
        }

    }
}