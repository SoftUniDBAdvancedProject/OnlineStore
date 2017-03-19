namespace Store.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public abstract class Context : IdentityDbContext<User>
    {
        protected Context(string conectionName, bool trowIfV1Shema)
            : base(conectionName, trowIfV1Shema)
        {
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
    }
}
