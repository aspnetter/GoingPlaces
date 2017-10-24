using System;
using System.Collections.Generic;

namespace Web.ViewModels.Trip
{
    public class TripListViewModel
    {
        public TripListViewModel()
        {
            Filter = new FilterViewModel();
        }
        public IEnumerable<TripListEntryViewModel> Trips { get; set; }
        public FilterViewModel Filter { get; set; }
    }
}
