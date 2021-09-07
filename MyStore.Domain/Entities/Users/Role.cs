using System.Collections.Generic;
using MyStore.Domain.Entities.Commons;

namespace MyStore.Domain.Entities.Users
{
    public class Role:BaseEntityNotID
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserInRole> UserInRoles { get; set; }
    }
}