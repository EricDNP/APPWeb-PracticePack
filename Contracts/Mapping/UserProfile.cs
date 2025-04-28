using AutoMapper;
using APPWEB_PracticePack.Models;
using APPWEB_PracticePack.Contracts.Adapters;

namespace APPWEB_PracticePack.Contracts.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserInfoAdapter, User>();
        }
    }
}
