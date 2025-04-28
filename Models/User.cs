using APPWEB_PracticePack.Models.Common;
using APPWEB_PracticePack.Models.Enums;

namespace APPWEB_PracticePack.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
        public UserRole Role { get; set; }

        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
        public ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
