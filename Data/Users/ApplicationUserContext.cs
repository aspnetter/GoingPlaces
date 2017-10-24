using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Users
{
    public class ApplicationUserContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationUserContext() { }
        public ApplicationUserContext(DbContextOptions<ApplicationUserContext> options)
            : base(options) { }
    }
}