using System.Linq;
using System.Threading.Tasks;
using Data.Trips;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Web.Authentication;
using Web.ViewModels.Trip;

namespace Web.Controllers
{
    [Authorize]
    public class TripController : Controller
    {
        private readonly TripService _tripService;
        private readonly AccountService _accountService;

        public TripController(TripService tripService, AccountService accountService)
        {
            _tripService = tripService;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var currentUserId = HttpContext.User.GetId();

            var tripsModel = new TripListViewModel
            {
                Trips = (
                await _tripService.ListTripsForUser(currentUserId))
                .Select(t => new TripListEntryViewModel(t))
                
            };

            return View(tripsModel);
        }

        [HttpGet]
        public async Task<IActionResult> Filter([FromQuery] FilterViewModel filter)
        {
            var trips = await _tripService.ListTripsForUser(
                HttpContext.User.GetId(),
                filter.FilterType,
                filter.DateFrom?.ToUniversalTime(),
                filter.DateTo?.ToUniversalTime());

            var tripsModel = new TripListViewModel
            {
                Trips = trips.Select(t => new TripListEntryViewModel(t)),           
                Filter = filter
            };

            return View("List", tripsModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEditTripViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _tripService.AddTrip(new Trip
            {
                UserId = (await _accountService.GetUser(HttpContext.User)).Id,
                From = viewModel.FromCountryCity,
                To = viewModel.ToCountryCity,
                StartDateUtc = viewModel.StartDate.ToUniversalTime(),
                EndDateUtc = viewModel.EndDate.ToUniversalTime(),
                Comments = viewModel.Comments
            });

            TempData["FlashMessage"] = "Your trip from " +
                                       $"{viewModel.FromCountryCity} to {viewModel.ToCountryCity} " +
                                       $"on {viewModel.StartDate}" +
                                       " added successfully";

            return RedirectToAction("List");
        }
    }
}
