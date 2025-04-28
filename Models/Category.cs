using APPWEB_PracticePack.Models.Common;

namespace APPWEB_PracticePack.Models
{
    public class Category : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
