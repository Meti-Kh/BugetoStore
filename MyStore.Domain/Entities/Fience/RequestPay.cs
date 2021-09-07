using MyStore.Domain.Entities.Commons;
using MyStore.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Entities.Fience
{
   public class RequestPay:BaseEntity
    {
        public Guid Guid { get; set; }
        public double Amount { get; set; }
        public virtual User User { get; set; }
        public long UserID { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDateTime { get; set; }
        public string Authority { get; set; }
        public long RefID { get; set; }
        public virtual ICollection<Order.Order> Orders { get; set; }
    }
}
