using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [Authorize]
    public class TripController : Controller
    {
        public IActionResult List()
        {
            return null;
        }
    }
}
