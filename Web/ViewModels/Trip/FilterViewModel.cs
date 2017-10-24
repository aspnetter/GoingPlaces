using System;
using Services;

namespace Web.ViewModels.Trip
{
    public class FilterViewModel
    {
        public FilterViewModel()
        {
            FilterType = TripFilterType.Upcoming;
        }

        public TripFilterType FilterType { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
