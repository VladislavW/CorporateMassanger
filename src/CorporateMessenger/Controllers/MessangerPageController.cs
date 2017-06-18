using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using CorporateMassenger.Data;
using CorporateMessenger.Services.Interfaces;
using CorporateMessenger.ViewModel;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CorporateMessenger.Controllers
{
    public class MessangerPageController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IUserService _userService;
        private readonly IHostingEnvironment _appEnvironment;

        public MessangerPageController(
             ApplicationContext context,
             IUserService userService,
             IHostingEnvironment appEnvironment)
        {
            _context = context;
            _userService = userService;
            _appEnvironment = appEnvironment;

        }

        [HttpGet]
        [Route("user/getcurrentuser")]
        public async Task<JsonResult> GetCurretUser()
        {
            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            string email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;

            var user = await _userService.GetCurrentUserByClimeEmeil(email);

            var userViewModel = new UserViewModel
            {
                Email = user.Email,
                Fullname = user.Fullname,
                Photo = string.IsNullOrEmpty(user.Photo) != null
                                      ? "/images/anonym.jpg"
                                      : user.Photo,
                Phone = user.Phone
            };
            return Json(userViewModel);

        }
        [HttpPut]
        [Route("user/updatecurrentuser")]
        public async Task<JsonResult> UpdateCurretUser([FromBody] UserViewModel userViewModel)
        {
            string email = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;

            var user = await _userService.GetCurrentUserByClimeEmeil(email);

            _userService.UpdateUserInfo(userViewModel, user.Id);

            return Json(userViewModel);

        }
        [HttpPost]
        [Route("user/addphotopath")]
        public async Task<JsonResult> AddPhtoPath(IFormFileCollection file)
        {
            if (file.Count != 0)
            {
                var path = await _userService.UploadPfoto(file, _appEnvironment);
                return Json(path);
            }
            else
            {
                return Json(404);
            }
        }


        [HttpGet]
        [Route("user/getuserbyid/{id}")]
        public async Task<JsonResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            var userViewModel = new UserViewModel
            {
                Email = user.Email,
                Fullname = user.Fullname,
                Photo = string.IsNullOrEmpty(user.Photo) != null
                                      ? "/images/anonym.jpg"
                                      : user.Photo,
                Phone = user.Phone
            };
            return Json(userViewModel);

        }
        [HttpDelete]
        public async Task<IActionResult> Logout(int id)
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");
            return StatusCode(201);
            //return RedirectToAction("Login", "Account");
        }
    }
}
