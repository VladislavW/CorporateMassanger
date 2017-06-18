using CorporateMessenger.Data.Mapping;
using System.Threading.Tasks;

namespace CorporateMessenger.Data.Interfaces
{
    internal interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetUserRoleByRoleNameAsync(string roleName);
    }
}
