using System.Linq;
using System.Security.Claims;

namespace Web.Authentication
{
    public static class ClaimsPrincipalExtension
    {
        public static int GetId(this ClaimsPrincipal principal)
        {
            var nameIdentifier = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return int.Parse(nameIdentifier?.Value);

        }
        public static string GetFirstName(this ClaimsPrincipal principal)
        {
            var firstName = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName);
            return firstName?.Value;
        }

        public static string GetLastName(this ClaimsPrincipal principal)
        {
            var lastName = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname);
            return lastName?.Value;
        }
    }
}