namespace Store.Data.EntityConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Models;

    public class OrderProductEntityConfiguration : EntityTypeConfiguration<OrderProduct>
    {
        public OrderProductEntityConfiguration()
        {
            this.HasKey(op => new { op.OrderId, op.ProductId });
        }
    }
}
