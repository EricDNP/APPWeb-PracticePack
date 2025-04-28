using APPWEB_PracticePack.Models.Common;
using APPWEB_PracticePack.Models.Enums;

namespace APPWEB_PracticePack.Models
{
    public class Order : BaseEntity
    {
        public DateTime OrderedDate { get; set; } = DateTime.UtcNow;
        public DateTime ArrivedDate { get; set; }
        public decimal Total => Items.Sum(i => i.TotalPrice);
        public DeliveryStatus Status { get; set; }

        public Guid CustomerId { get; set; }
        public User? Customer { get; set; }

        public Guid AddressId { get; set; }
        public Address? Address { get; set; }

        public Guid PaymentId { get; set; }
        public Payment? Payment { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
    }
}
