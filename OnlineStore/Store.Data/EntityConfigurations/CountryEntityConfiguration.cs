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
            this.Property(t => t.Name)
               .IsRequired()
               .HasMaxLength(255)
               .HasColumnAnnotation(
                   IndexAnnotation.AnnotationName,
                   new IndexAnnotation(
                       new IndexAttribute("IX_Name") { IsUnique = true }));
        }
    }
}
