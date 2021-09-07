using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyStore.Domain.Entities.Products;
using MyStore.Domain.Entities.HomePage;
using MyStore.Domain.Entities.Cart;
using MyStore.Domain.Entities.Fience;
using MyStore.Domain.Entities.Order;

namespace MyStore.Application.Interfaces.Context
{
   public interface IDatabaseContext
    {
         DbSet<User> Users { get; set; }
         DbSet<Role> Roles { get; set; }
         DbSet<UserInRole> UserInRoles { get; set; }
         DbSet<Category> Categories { get; set; }
        DbSet<Products> Products { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<ProductFeatures> ProductFeatures { get; set; }
        DbSet<Slider> Sliders { get; set; }
        DbSet<HomePageImages> HomePageImages { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<RequestPay> RequestPays { get; set; }
        DbSet<CartItams> CartItams { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }

//mother
        int SaveChanges(bool acceptAllChangesOnSuccess);
         int SaveChanges();
         Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
         Task<int> SaveChangesAsync(CancellationToken cancellationToken=new CancellationToken());
    }
}
