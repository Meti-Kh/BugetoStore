using MyStore.Domain.Entities.Commons;

namespace MyStore.Domain.Entities.Users
{
    public class UserInRole:BaseEntity
    {
        public long ID { get; set; }
        public virtual User User { get; set; }
        public long UserID { get; set; }
        public virtual Role Role { get; set; }
        public int RoleID { get; set; }
      
    }
}