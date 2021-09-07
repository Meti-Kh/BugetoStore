using MyStore.Domain.Entities.Commons;

namespace MyStore.Domain.Entities.Order
{
    public class OrderDetail:BaseEntity
    {
        public Order Order { get; set; }
        public long OrderID { get; set; }

        public virtual Products.Products Product { get; set; }
        public long ProductID { get; set; }

        public double Price { get; set; }
        public int Count { get; set; }
    }
}
