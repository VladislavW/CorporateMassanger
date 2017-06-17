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
        private readonly IUserRepositoty _userRepositoty;

        public SingInWithGoogleService(
             IUserRepositoty userRepositoty)
        {
            _userRepositoty = userRepositoty;
        }

        public async Task<ClaimsIdentity> AuthenticateAsync(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                  new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)

            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            return id;
        }

        public async Task<User> GoogleLoginCallbackAsync(string email)
        {
            User userdb = await _userRepositoty.GetUserByEmailAsync(email);

            if (userdb == null)
            {
                User user = new User { Email = email };
                _userRepositoty.Add(user);
                 return user;
            } else  {
                return userdb;
            }
        }
    }
}
