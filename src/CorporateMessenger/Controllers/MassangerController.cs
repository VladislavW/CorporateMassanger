using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorporateMessenger.Controllers
{

    [RequireHttps]

    public class MassangerController : Controller
    {
        [Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Redirect("singin/index");
            }
        }
    }
}
