using CorporateMessenger.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporateMassenger.Data.Mapping;
using CorporateMessenger.Data.Interfaces;
using CorporateMessenger.ViewModel;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CorporateMessenger.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly IUserRepository _userRepositoty;

        public UserService(
             IUserRepository userRepositoty)
        {
            _userRepositoty = userRepositoty;
        }

        public async Task<User> GetCurrentUserByClimeEmeil(string email)
        {
            return await _userRepositoty.GetUserByEmailAsync(email);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepositoty.FindAsync(id);
        }

        public void UpdateUserInfo(UserViewModel userViewModel, int userId)
        {
            var user = new User
            {
                Id = userId,
                Email = userViewModel.Email,
                Fullname = userViewModel.Fullname,
                Photo = userViewModel.Photo,
                Phone = userViewModel.Phone
            };
            _userRepositoty.Update(user);
            _userRepositoty.SaveChanges();

        }

        public async Task<string> UploadPfoto(IFormFileCollection file, IHostingEnvironment appEnvironment)
        {
            string path = "/images/userPhoto/" + file[0].FileName;
            using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await file[0].CopyToAsync(fileStream);
            }
            return path;
        }
    }
}
