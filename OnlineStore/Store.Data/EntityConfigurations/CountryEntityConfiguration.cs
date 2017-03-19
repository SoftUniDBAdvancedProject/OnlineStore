namespace Store.Data.EntityConfigurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration;
    using Models;

    public class CountryEntityConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryEntityConfiguration()
        {
            this.Property(c => c.Name)
              .IsRequired()
              .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute { IsUnique = true }));
        }
    }
}
