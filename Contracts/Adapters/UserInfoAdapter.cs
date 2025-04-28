using APPWEB_PracticePack.Models;
using APPWEB_PracticePack.Contracts.Mapping.Çommon;
using APPWEB_PracticePack.Models.Enums;

namespace APPWEB_PracticePack.Contracts.Adapters
{
    public class UserInfoAdapter
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Document { get; set; }
        public string? Mobile { get; set; }
        public string? Phone { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public UserRole Role { get; set; }

        public static UserInfoAdapter Adapt (User user)
        {
            return ProfileMapper.Map<UserInfoAdapter, User>(user);
        }
    }
}
