using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStore.Domain.Entities.Commons;

namespace MyStore.Domain.Entities.Products
{
   public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public Category ParentCategory { get; set; }
        public long? ParentCategoryId { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
