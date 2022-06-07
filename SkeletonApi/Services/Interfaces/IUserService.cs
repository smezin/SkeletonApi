using System.Threading.Tasks;
using SkeletonApi.Auth;
using SkeletonApi.Models.AppRequests;

namespace SkeletonApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model);
        Task<string> RegisterAsync(RegisterModel model);
    }
}
