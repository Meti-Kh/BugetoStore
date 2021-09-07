using MyStore.Domain.Entities.Commons;

namespace MyStore.Domain.Entities.Products
{
    public class ProductImage : BaseEntity
    {

        public virtual Products Product { get; set; }
        public int ProductID { get; set; }
        public string Src { get; set; }


    }
}
