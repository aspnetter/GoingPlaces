using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Users
{
    public class ApplicationUserContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationUserContext(DbContextOptions<ApplicationUserContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("application_Users");
            builder.Entity<ApplicationRole>().ToTable("application_Roles");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("application_RoleClaims");
            builder.Entity<IdentityUserClaim<int>>().ToTable("application_UserClaims");
            builder.Entity<IdentityUserLogin<int>>().ToTable("application_UserLogins");
            builder.Entity<IdentityUserRole<int>>().ToTable("application_UserRoles");
            builder.Entity<IdentityUserToken<int>>().ToTable("application_UserTokens");
        }
    }
}