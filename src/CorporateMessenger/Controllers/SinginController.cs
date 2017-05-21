using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

//если юзер авторизирован возвращает базовую страницу авторизированого пользователя
namespace CVAcropolium.Controllers
{

    [RequireHttps]
    [Route("account/login")]
    public class SinginController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                if (role == "admin" || role == "user")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Result", "Confirm");
                }

            }
            else
            {
                return View();
            }
        }
    }
}
