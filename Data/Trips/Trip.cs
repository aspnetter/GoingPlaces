using System;
using System.ComponentModel.DataAnnotations;
using Data.Users;

namespace Data.Trips
{
    public class Trip
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [MaxLength(length: 64)]
        public string From { get; set; }
        [MaxLength(length: 64)]
        public string To { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime EndDateUtc { get; set; }

        [MaxLength(length: 500)]
        public string Comments { get; set; }
        public int UserId { get; set; }
    }
}
