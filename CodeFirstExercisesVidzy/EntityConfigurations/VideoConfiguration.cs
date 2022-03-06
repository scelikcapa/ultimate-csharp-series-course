using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExercisesVidzy.EntityConfigurations
{
    public class VideoConfiguration: EntityTypeConfiguration<Video>
    {
        public VideoConfiguration()
        {
            Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(v => v.Genre)
                .WithMany(v => v.Videos)
                .Map(m =>
                {
                    m.MapKey("GenreId");
                });
        }
    }
}
