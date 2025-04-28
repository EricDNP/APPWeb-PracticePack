using APPWEB_PracticePack.Models.Common;

namespace APPWEB_PracticePack.Models
{
    public class Payment : BaseEntity
    {
        public string Label { get; set; } = string.Empty;
        public string Holder { get; set; } = string.Empty;
        public int Number { get; set; }
        public DateTime Expiration { get; set; }
        public int CVV { get; set; }
        public bool Default { get; set; } = false;

        public Guid CustomerId { get; set; }
        public User? Customer { get; set; }
    }
}
