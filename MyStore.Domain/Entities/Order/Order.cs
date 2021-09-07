using MyStore.Domain.Entities.Commons;
using MyStore.Domain.Entities.Fience;
using MyStore.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStore.Domain.Entities.Products;

namespace MyStore.Domain.Entities.Order
{
    public class Order:BaseEntity
    {
        public string Address { get; set; }
        public virtual User User { get; set; }
        public long UserID { get; set; }

        public virtual RequestPay RequestPay { get; set; }
        public long RequestPayID { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public OrderState OrderState { get; set; }
    }

   public enum OrderState
    {
        Processing = 0,
        Canceled = 1,
        Delivered = 2,
    }
}
