using Microsoft.EntityFrameworkCore;

namespace Data.Trips
{
    public class TripContext: DbContext
    {
        public TripContext()
        { }

        public TripContext(DbContextOptions<TripContext> options)
            : base(options)
        { }

        public DbSet<Trip> Trips { get; set; }
    }
}
