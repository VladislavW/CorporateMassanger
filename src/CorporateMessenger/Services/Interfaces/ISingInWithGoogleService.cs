using CorporateMassenger.Data.Mapping;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CorporateMessenger.Services.Interfaces
{
    public interface ISingInWithGoogleService
    {
        Task<ClaimsIdentity> AuthenticateAsync(User user);
        Task<User> GoogleLoginCallbackAsync(string email);
    }
}
