using MyStore.Domain.Entities.Commons;

namespace MyStore.Domain.Entities.Products
{
    public class ProductFeatures:BaseEntity
    {
        public Products Product { get; set; }
        public long ProductID { get; set; }
        public string DisPlayName { get; set; }
        public string Value { get; set; }

    }
}
