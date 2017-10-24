using System;

namespace Web.ViewModels.Trip
{
    public class TripListEntryViewModel
    {
        public TripListEntryViewModel(Data.Trips.Trip trip)
        {
            Title = $"{trip.From} => {trip.To}";
            StartDate = GetLocalShortDateString(trip.StartDateUtc);
            EndDate = GetLocalShortDateString(trip.EndDateUtc);
            DurationDays = (trip.EndDateUtc - trip.StartDateUtc).Days;
            Comments = trip.Comments;
        }

        public string Title { get; }
        public string StartDate { get; }
        public string EndDate { get; }
        public int DurationDays { get; }
        public string Comments { get; set; }

        private string GetLocalShortDateString(DateTime date)
        {
            return TimeZoneInfo
                .ConvertTimeFromUtc(date, TimeZoneInfo.Local)
                .ToShortDateString();
        }
    }
}
