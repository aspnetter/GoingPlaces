using System;
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

        private readonly Func<Trip, bool> _futureTrip = t => t.StartDateUtc >= DateTime.UtcNow.Date;
        private readonly Func<Trip, bool> _pastTrip = t => t.EndDateUtc < DateTime.UtcNow.Date;

        private readonly Func<Trip, DateTime?, bool> _overlapStart = (t, d) => !d.HasValue || t.StartDateUtc >= d.Value || t.EndDateUtc >= d.Value;
        private readonly Func<Trip, DateTime?, bool> _overlapEnd = (t, d) => !d.HasValue || t.EndDateUtc <= d.Value;
        public TripService(TripContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Trip>> ListTripsForUser(int userId, TripFilterType filter = TripFilterType.Upcoming,
            DateTime? filterStartDate = null, DateTime? filterEndDate = null)
        {
            var tripQuery = _dbContext.Trips.Where(t => t.UserId == userId);

            tripQuery = tripQuery
                .Where(t =>
                    filter == TripFilterType.All ||
                    filter == TripFilterType.Upcoming && _futureTrip(t) ||
                    filter == TripFilterType.Past && _pastTrip(t))
                .Where(t => _overlapStart(t, filterStartDate))
                .Where(t => _overlapEnd(t, filterEndDate));

            return await tripQuery.ToListAsync();
        }
        public async Task<Trip> AddTrip(Trip trip)
        {
            var added = await _dbContext.AddAsync(trip);
            await _dbContext.SaveChangesAsync();

            return added.Entity;
        }
    }
}
