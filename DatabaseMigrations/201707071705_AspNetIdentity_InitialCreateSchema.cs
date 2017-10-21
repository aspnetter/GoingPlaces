using System.Data;
using FluentMigrator;

namespace DatabaseMigrations
{
    [Migration(201707071705)]
    public class AspNetIdentityInitialCreateSchema : Migration
    {
        public override void Up()
        {
            Create.Table("application_Roles")
                .WithColumn("Id").AsInt32().NotNullable()
                    .PrimaryKey("PK_application_Roles").Identity()
                .WithColumn("ConcurrencyStamp").AsString().Nullable()
                .WithColumn("Name").AsString(256).Nullable()
                .WithColumn("NormalizedName").AsString(256).Nullable()
                    .Indexed("RoleNameIndex").Unique();

            Create.Table("application_Users")
                .WithColumn("Id").AsInt32().NotNullable()
                    .PrimaryKey("PK_application_Users").Identity()
                .WithColumn("AccessFailedCount").AsInt32().NotNullable()
                .WithColumn("ConcurrencyStamp").AsString().Nullable()
                .WithColumn("Email").AsString(256).NotNullable()
                .WithColumn("EmailConfirmed").AsBoolean().NotNullable()
                .WithColumn("LockoutEnabled").AsBoolean().NotNullable()
                .WithColumn("LockoutEnd").AsDateTimeOffset().Nullable()
                .WithColumn("NormalizedEmail").AsString(256).Nullable()
                    .Indexed("EmailIndex").Unique()
                .WithColumn("NormalizedUserName").AsString(256).Nullable()
                    .Indexed("UserNameIndex").Unique()
                .WithColumn("PasswordHash").AsString().Nullable()
                .WithColumn("PhoneNumber").AsString().Nullable()
                .WithColumn("PhoneNumberConfirmed").AsBoolean().Nullable()
                .WithColumn("SecurityStamp").AsString().Nullable()
                .WithColumn("TwoFactorEnabled").AsBoolean().NotNullable()
                .WithColumn("UserName").AsString(256).Nullable();

            Create.Table("application_UserTokens")
                .WithColumn("UserId").AsInt32().NotNullable()
                    .PrimaryKey("PK_application_UserTokens")
                .WithColumn("LoginProvider").AsString().NotNullable()
                    .PrimaryKey("PK_application_UserTokens")
                .WithColumn("Name").AsString().NotNullable()
                    .PrimaryKey("PK_application_UserTokens")
                .WithColumn("Value").AsString().Nullable();

            Create.Table("application_RoleClaims")
                .WithColumn("Id").AsInt32().NotNullable()
                    .PrimaryKey("PK_application_RoleClaims").Identity()
                .WithColumn("ClaimType").AsString().Nullable()
                .WithColumn("ClaimValue").AsString().Nullable()
                .WithColumn("RoleId").AsInt32().NotNullable()
                    .ForeignKey("FK_application_RoleClaims_application_Roles_RoleId", "application_Roles", "Id").OnDelete(Rule.Cascade)
                    .Indexed("IX_application_RoleClaims_RoleId");
                   
            Create.Table("application_UserClaims")
                .WithColumn("Id").AsInt32().NotNullable()
                    .PrimaryKey("PK_application_UserClaims").Identity()
                .WithColumn("ClaimType").AsString().Nullable()
                .WithColumn("ClaimValue").AsString().Nullable()
                .WithColumn("UserId").AsInt32().NotNullable()
                    .ForeignKey("FK_application_UserClaims_application_Users_UserId", "application_Users", "Id").OnDelete(Rule.Cascade)
                    .Indexed("IX_application_UserClaims_UserId");

            Create.Table("application_UserLogins")
                .WithColumn("LoginProvider").AsString().NotNullable()
                    .PrimaryKey("PK_application_UserLogins")
                .WithColumn("ProviderKey").AsString().NotNullable()
                    .PrimaryKey("PK_application_UserLogins")
                .WithColumn("ProviderDisplayName").AsString().Nullable()
                .WithColumn("UserId").AsInt32().NotNullable()
                    .ForeignKey("FK_application_UserLogins_application_Users_UserId", "application_Users", "Id").OnDelete(Rule.Cascade)
                    .Indexed("IX_application_UserLogins_UserId");

            Create.Table("application_UserRoles")
                .WithColumn("UserId").AsInt32().NotNullable()
                    .PrimaryKey("PK_application_UserRoles")
                    .ForeignKey("FK_application_UserRoles_application_Users_UserId", "application_Users", "Id").OnDelete(Rule.Cascade)
                .WithColumn("RoleId").AsInt32().NotNullable()
                    .PrimaryKey("PK_application_UserRoles")
                    .ForeignKey("FK_application_UserRoles_application_Roles_RoleId", "application_Roles", "Id").OnDelete(Rule.Cascade)
                    .Indexed("IX_application_UserRoles_RoleId");
        }
       
        public override void Down()
        {
            Delete.Table("application_RoleClaims");
            Delete.Table("application_UserClaims");
            Delete.Table("application_UserLogins");
            Delete.Table("application_UserRoles");
            Delete.Table("application_UserTokens");
            Delete.Table("application_Roles");
            Delete.Table("application_Users");
        }
    }
}
