using Newtonsoft.Json;
using APPWEB_PracticePack.Models.Common;
using APPWEB_PracticePack.Configuration;
using APPWEB_PracticePack.Services.Common;
using APPWEB_PracticePack.Contracts.Adapters;
using APPWEB_PracticePack.Contracts.Commands;
using APPWEB_PracticePack.Services.Interfaces;

namespace APPWEB_PracticePack.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly string path = "users";

        public UserService(ApiSettings apiSettings, IHttpContextAccessor contextAccessor)
            : base(apiSettings, contextAccessor)
        {
            
        }

        public async Task<UserInfoAdapter> Login(LoginContract contract)
        {
            using (var client = GetClient())
            {
                var response = await client.PostAsJsonAsync<LoginContract>($"{path}/login", contract);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        var adapter = JsonConvert.DeserializeObject<UserInfoAdapter>(content);
                        return adapter;
                    }
                    else
                    {
                        throw new Exception("Failed Login");
                    }
                }
                else
                {
                    throw new Exception("Server Error");
                }
            }
        }

        public async Task<BaseEntity> Register(RegisterContract contract)
        {
            using (var client = GetClient())
            {
                var response = await client.PostAsJsonAsync<RegisterContract>($"{path}/register", contract);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrWhiteSpace(content))
                    {
                        var adapter = JsonConvert.DeserializeObject<BaseEntity>(content);
                        return adapter;
                    }
                    else
                    {
                        throw new Exception("Failed Register");
                    }
                }
                else
                {
                    throw new Exception("Server Error");
                }
            }
        }
    }
}
