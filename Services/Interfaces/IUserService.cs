using APPWEB_PracticePack.Models.Common;
using APPWEB_PracticePack.Services.Common;
using APPWEB_PracticePack.Contracts.Adapters;
using APPWEB_PracticePack.Contracts.Commands;

namespace APPWEB_PracticePack.Services.Interfaces
{
    public interface IUserService : IBaseService
    {
        Task<UserInfoAdapter> Login(LoginContract contract);
        Task<BaseEntity> Register(RegisterContract contract);
    }
}
