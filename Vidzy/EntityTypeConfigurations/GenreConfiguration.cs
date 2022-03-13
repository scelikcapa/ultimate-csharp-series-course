using System.Data.Entity.ModelConfiguration;

namespace VidzyFirst.EntityTypeConfigurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
