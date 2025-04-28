namespace APPWEB_PracticePack.Contracts.Commands
{
    public class RegisterContract
    {
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Document { get; set; }
        public string? Mobile { get; set; }
        public string? Phone { get; set; }

        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }

    }
}
