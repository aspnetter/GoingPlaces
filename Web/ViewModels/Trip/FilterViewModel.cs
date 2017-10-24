using System;

namespace Web.ViewModels.Trip
{
    public class FilterViewModel
    {
        public FilterViewModel()
        {
            DisplayType = TripDisplayType.Upcoming;
            //DateFrom = DateTime.Now.Date; 
            //DateTo = DateTime.Now.AddYears(1).Date;
        }

        public TripDisplayType DisplayType { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
