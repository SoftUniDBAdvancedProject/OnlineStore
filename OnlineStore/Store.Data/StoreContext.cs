namespace Store.Data
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class StoreContext : IdentityDbContext<User>
    {
        public StoreContext()
            : base("OnlineStoreConection", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoreContext, Configuration>());
        }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<CartProduct> CartProducts { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderProduct> OrderProducts { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        public static StoreContext Create()
        {
            return new StoreContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<CartProduct>()
               .HasKey(op => new { op.CartId, op.ProductId });

            modelBuilder.Entity<User>()
                .HasOptional(c => c.Cart)
                .WithRequired(u => u.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}