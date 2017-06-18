using CorporateMassenger.Data.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CorporateMessenger.Data.Interfaces
{
    internal interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserWithRoleByEmailAsync(string email);
        Task<List<User>> GetUsersByGroupAsync(string groupName);
    }
}
