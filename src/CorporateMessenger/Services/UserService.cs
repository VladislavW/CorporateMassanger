using CorporateMessenger.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporateMassenger.Data.Mapping;
using CorporateMessenger.Data.Interfaces;
using CorporateMessenger.ViewModel;

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
    }
}
