using APPWEB_PracticePack.Models.Common;

namespace APPWEB_PracticePack.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public required string Image { get; set; }
        public bool Hidden { get; set; } = false;

        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
