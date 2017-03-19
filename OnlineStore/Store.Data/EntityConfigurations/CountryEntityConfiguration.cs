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
                .HasColumnType("nvarchar(255)")
               .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Name") { IsUnique = true })); ;
        }
    }
}
