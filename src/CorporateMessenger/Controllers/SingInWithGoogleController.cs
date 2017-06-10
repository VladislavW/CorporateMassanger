using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.Extensions.Configuration;
using System.IO;
using CorporateMassenger.Data.Mapping;
using CorporateMassenger.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CorporateMessenger.Controllers
{
    [Authorize]
    [Route("apicvprofgoo/[controller]")]

    public class SingInWithGoogleController : Controller
    {
        private readonly ApplicationContext _context;

        public SingInWithGoogleController(ApplicationContext context)
        {
            _context = context;

        }
        [HttpPost]
        [AllowAnonymous]
        public async Task ExternalLogin([FromBody] User us)
        {
            string returnUrl = null;
              var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleLoginCallback",
                     new { returnUrl = returnUrl })
            };
            try
            {
                await HttpContext.Authentication.ChallengeAsync("Google", properties);
            }
            catch
            {
                Response.StatusCode = 205;
            }
            
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GoogleLoginCallback(string returnUrl = null, string remoteError = null)
        {
            var email = HttpContext.Authentication.GetAuthenticateInfoAsync("Google").Result.Principal.FindFirstValue(ClaimTypes.Email);

            if (email != null)
            {
                var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables()
               .Build();


                String corporateEmail = config.GetSection("AppSeating:corporateMail").Value;

                if (email.EndsWith(corporateEmail))
                {
                    User userdb = await _context.UserMap
                      .FirstOrDefaultAsync(u => u.Email == email);
                    if (userdb == null)
                    {
                     
                        User user = new User { Email = email};
                        _context.UserMap.Add(user);

                       
                        await Authenticate(user);
                    }
                    else
                    {
                        await Authenticate(userdb);
                    }
                    return RedirectToAction("Index", "Massangaer");
                }
                else
                {  
                    User user = new User { Email = email};
                    await Authenticate(user);

               
                    return RedirectToAction("Result", "Confirm");
                }
            }
            else
            {
                return RedirectToAction("Index", "Singin");
            }


        }
        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                  new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)

            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.Authentication.SignInAsync("Cookies", new ClaimsPrincipal(id));
        }
    }
}
