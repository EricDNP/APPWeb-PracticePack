using APPWEB_PracticePack.Models.Common;

namespace APPWEB_PracticePack.Models
{
    public class Address : BaseEntity
    {
        public string Label { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public bool Default { get; set; } = false;

        public Guid CustomerId { get; set; }
        public User? Customer { get; set; }
    }
}
