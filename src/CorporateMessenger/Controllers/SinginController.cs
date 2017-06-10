using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

//если юзер авторизирован возвращает базовую страницу авторизированого пользователя
namespace CorporateMessenger.Controllers
{

    [RequireHttps]
    [Route("singin/index")]
    public class SinginController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}
