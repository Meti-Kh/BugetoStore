using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStore.Domain.Entities.Commons;

namespace MyStore.Domain.Entities.Users
{
   public class User:BaseEntity
    {
      
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<UserInRole> UserInRoles { get; set; }
        public virtual ICollection<Order.Order> Orders { get; set; }
    }
}
