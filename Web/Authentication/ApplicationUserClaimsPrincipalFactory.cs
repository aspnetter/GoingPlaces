using System.Security.Claims;
using System.Threading.Tasks;
using Data.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Web.Authentication
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
    {
        public ApplicationUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager, 
            RoleManager<ApplicationRole> roleManager, 
            IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        {
        }

        public override async Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            var claimsIdentity = ((ClaimsIdentity)principal.Identity);

            claimsIdentity.AddClaims(new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), 
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName)
            });
        
            return principal;
        }
    }
}
