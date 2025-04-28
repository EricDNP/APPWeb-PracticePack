using APPWEB_PracticePack.Models.Common;

namespace APPWEB_PracticePack.Models
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal TotalPrice => Product != null ? Quantity * Product.Price : 0;

        public Guid OrderId { get; set; }
        public Order? Order { get; set; }

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
