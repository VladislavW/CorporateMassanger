using CorporateMessenger.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporateMassenger.Data.Mapping;
using System.Security.Claims;
using CorporateMessenger.Data.Interfaces;

namespace CorporateMessenger.Services
{
    internal sealed class SingInWithGoogleService : ISingInWithGoogleService
    {
        private readonly IUserRepository _userRepositoty;
        private readonly IRoleRepository _roleRepositoty;

        public SingInWithGoogleService(
             IUserRepository userRepositoty,
             IRoleRepository roleRepositoty)
        {
            _userRepositoty = userRepositoty;
            _roleRepositoty = roleRepositoty;
        }

        public async Task<ClaimsIdentity> AuthenticateAsync(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                  new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                  new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)

            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            return id;
        }

        public async Task<User> GoogleLoginCallbackAsync(string email)
        {
            User userdb = await _userRepositoty.GetUserWithRoleByEmailAsync(email);

            if (userdb == null)
            {
                var role = await _roleRepositoty.GetUserRoleByRoleNameAsync("user");

                User user = new User { Email = email, Role = role};

                _userRepositoty.Add(user);
                _userRepositoty.SaveChanges();

                 return user;
            } else  {
                return userdb;
            }
        }
    }
}
