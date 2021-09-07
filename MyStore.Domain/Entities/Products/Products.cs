using MyStore.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Entities.Products
{
    public class Products : BaseEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Invertory { get; set; }
        public bool DisPlayed { get; set; }
        public double Price { get; set; }
        public long ViewCount { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
        public long CategoryID { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductFeatures> ProductFeatures { get; set; }
        public virtual ICollection<Order.OrderDetail> OrderDetails { get; set; }


    }
}
