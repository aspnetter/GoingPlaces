using System;

namespace Web.ViewModels.Trip
{
    public class TripListEntryViewModel
    {
        public string Title { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int DurationDays { get; set; }
    }
}
