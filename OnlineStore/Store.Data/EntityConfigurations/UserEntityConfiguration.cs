namespace Store.Data.EntityConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Models;

    public class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            this.HasOptional(c => c.Cart)
                 .WithRequired(u => u.User);
        }
    }
}
