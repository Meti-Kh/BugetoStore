using MyStore.Domain.Entities.Commons;
using MyStore.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Entities.Cart
{
   public class Cart:BaseEntity
    {
        public virtual User User { get; set; }
        public long? UserID { get; set; }
        public Guid BrowserID { get; set; }
        public bool Finished { get; set; }
        public ICollection<CartItams>CartItams { get; set; }

    }

    public class CartItams:BaseEntity
    {
        public Products.Products Product { get; set; }
        public long ProductID { get; set; }

        public int Count { get; set; }
        public double Price { get; set; }

        public virtual Cart Cart { get; set; }
        public long CartID { get; set; }

    }
}
