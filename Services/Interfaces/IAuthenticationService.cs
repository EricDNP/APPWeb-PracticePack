using APPWEB_PracticePack.Contracts.Adapters;

namespace APPWEB_PracticePack.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task LogInClaims(UserInfoAdapter user);
    }
}
