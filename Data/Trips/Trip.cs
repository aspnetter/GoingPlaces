using System;
using Data.Users;

namespace Data.Trips
{
    public class Trip
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comments { get; set; }

        public ApplicationUser User { get; set; }
    }
}
