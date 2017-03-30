namespace Store.Data.EntityConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Models;

    public class CartProductEntityConfiguration : EntityTypeConfiguration<CartProduct>
    {
        public CartProductEntityConfiguration()
        {
            this.HasKey(op => new { op.CartId, op.ProductId});
        }
    }
}
