using CorporateMassenger.Data.Mapping;
using System.Threading.Tasks;

namespace CorporateMessenger.Data.Interfaces
{
    internal interface IUserRepositoty : IRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
