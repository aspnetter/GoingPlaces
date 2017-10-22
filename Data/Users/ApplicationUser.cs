using System.Collections;
using System.Collections.Generic;
using Data.Trips;
using Microsoft.AspNetCore.Identity;

namespace Data.Users
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Trip> Trips { get; set; }
    }
}
