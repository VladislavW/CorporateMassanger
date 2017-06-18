using CorporateMassenger.Data.Mapping;
using CorporateMessenger.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateMessenger.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetCurrentUserByClimeEmeil(string emsil);
        Task<User> GetUserById(int id);
        void UpdateUserInfo(UserViewModel userViewModel,int userId);
        Task<string> UploadPfoto(IFormFileCollection file, IHostingEnvironment appEnvironment);

    }
}
