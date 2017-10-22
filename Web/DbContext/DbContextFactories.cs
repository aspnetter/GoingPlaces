using Data.Trips;
using Data.Users;

namespace Web.DbContext
{
    public class ApplicationUserDesignTimeDbContextFactory : DesignTimeDbContextFactory<ApplicationUserContext>
    {
    }
    public class TripsDesignTimeDbContextFactory : DesignTimeDbContextFactory<TripContext>
    {
    }
}
