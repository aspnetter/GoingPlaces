using FluentMigrator;

namespace DatabaseMigrations
{
    [Migration(201707121000)]
    public class AspNetIdentityAddUserFirstLastName : Migration
    {
        private const int NameFieldLength = 64;
        public override void Up()
        {
            Alter
                .Table("application_Users")
                .AddColumn("FirstName").AsString(NameFieldLength).NotNullable()
                .AddColumn("LastName").AsString(NameFieldLength).NotNullable();
        }

        public override void Down()
        {
            Delete.Column("FirstName").FromTable("application_Users");
            Delete.Column("LastName").FromTable("application_Users");
        }
    }
}
