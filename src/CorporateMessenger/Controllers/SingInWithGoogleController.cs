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
using CorporateMessenger.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CorporateMessenger.Controllers
{
    [Authorize]
    [Route("apicvprofgoo/[controller]")]

    public class SingInWithGoogleController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ISingInWithGoogleService _singInWithGoogleService;

        public SingInWithGoogleController(
             ApplicationContext context,
             ISingInWithGoogleService singInWithGoogleService)
        {
            _context = context;
            _singInWithGoogleService = singInWithGoogleService;

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
                    var user = await _singInWithGoogleService.GoogleLoginCallbackAsync(email);

                    await Authenticate(user);

                    return RedirectToAction("Index", "Massangaer");
                }
                else
                {
                    User user = new User { Email = email };
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
            var id = await _singInWithGoogleService.AuthenticateAsync(user);
            await HttpContext.Authentication.SignInAsync("Cookies", new ClaimsPrincipal(id));
        }
    }
}
