using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Trips;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class TripService
    {
        private readonly TripContext _dbContext;

        public TripService(TripContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Trip>> List()
        {
            return await _dbContext.Trips.ToListAsync();
        }
        public async Task<Trip> AddTrip(Trip trip)
        { 
            var added = await _dbContext.AddAsync(trip);
            await _dbContext.SaveChangesAsync();

            return added.Entity;
        }
    }
}
