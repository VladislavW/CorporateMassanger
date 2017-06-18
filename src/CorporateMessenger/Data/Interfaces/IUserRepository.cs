using CorporateMassenger.Data.Mapping;
using System.Threading.Tasks;

namespace CorporateMessenger.Data.Interfaces
{
    internal interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserWithRoleByEmailAsync(string email);
    }
}
