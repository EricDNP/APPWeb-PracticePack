using System.Security.Claims;
using System.Net.Http.Headers;
using APPWEB_PracticePack.Configuration;

namespace APPWEB_PracticePack.Services.Common
{
    public abstract class BaseService
    {
        private readonly ApiSettings _settings;
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        protected BaseService(ApiSettings apiSettings, IHttpContextAccessor contextAccessor)
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(apiSettings.BaseUrl);

            _settings = apiSettings;
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
        }

        protected HttpClient GetClient()
        {
            var token = _contextAccessor.HttpContext?.User.FindFirstValue(_settings.TokenName);

            if(!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return _httpClient;
        }
    }
}
