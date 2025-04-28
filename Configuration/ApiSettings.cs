namespace APPWEB_PracticePack.Configuration
{
    public class ApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;
        public int TokenDuration { get; set; }
        public string TokenName { get; } = "AccessToken";
    }
}
