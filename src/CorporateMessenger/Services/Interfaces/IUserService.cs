using CorporateMassenger.Data.Mapping;
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

    }
}
