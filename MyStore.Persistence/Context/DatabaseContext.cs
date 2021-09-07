using Microsoft.EntityFrameworkCore;
using MyStore.Application.Interfaces.Context;
using MyStore.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStore.Common.Role;
using MyStore.Domain.Entities.Products;
using MyStore.Domain.Entities.HomePage;
using MyStore.Domain.Entities.Cart;
using MyStore.Domain.Entities.Fience;
using MyStore.Domain.Entities.Order;

namespace MyStore.Persistence.Context
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserInRole> UserInRoles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<ProductFeatures> ProductFeatures { get; set; }
        public virtual DbSet<HomePageImages> HomePageImages { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItams> CartItams { get; set; }
        public virtual DbSet<RequestPay> RequestPays { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { ID = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { ID = 2, Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { ID = 3, Name = nameof(UserRoles.Customer) });

            
            
            modelBuilder.Entity<User>().HasIndex(e => e.Email).IsUnique();



            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Products>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ProductImage>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<ProductFeatures>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Slider>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<HomePageImages>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Cart>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<CartItams>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<RequestPay>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Order>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<OrderDetail>().HasQueryFilter(p => !p.IsRemoved);





            modelBuilder.Entity<Order>()
                    .HasOne(p => p.RequestPay)
                    .WithMany(p => p.Orders)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                 .HasOne(p => p.User)
                 .WithMany(p => p.Orders)
                 .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
