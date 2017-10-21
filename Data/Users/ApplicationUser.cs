using Microsoft.AspNetCore.Identity;

namespace Data.Users
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
