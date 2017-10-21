using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Data.Users;
using Microsoft.AspNetCore.Identity;

namespace Services
{
    public class AuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        private const string TwoFactorTokenProvider = "Phone";
 
        public AuthService(
            SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<SignInResult> PasswordSignInAsync(string loginEmail, string password)
        {
            return await _signInManager.PasswordSignInAsync(
                loginEmail,
                password,
                isPersistent: false,
                lockoutOnFailure: false
            );
        }

        public async Task<string> GenerateTwoFactorTokenAsync()
        {
            var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

            if (user == null)
            {
                throw new AuthenticationException("Invalid user");
            }

            var provider = (await _userManager.GetValidTwoFactorProvidersAsync(user))
                .FirstOrDefault
                (p => p.StartsWith(TwoFactorTokenProvider)
                );

            if (provider == null)
            {
                throw new AuthenticationException("Two-factor Authentication is not configured");
            }

            return await _userManager.GenerateTwoFactorTokenAsync(user, provider);
        }

        public async Task<SignInResult> TwoFactorSignInAsync(string code)
        {
            return await _signInManager.TwoFactorSignInAsync(
                TwoFactorTokenProvider,
                code,
                isPersistent: false,
                rememberClient: false
            );
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
