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


            // Mosh Solution
            //HasRequired(v => v.Genre)
            //    .WithMany(g => g.Videos)
            //    .HasForeignKey(v => v.GenreId);

            HasMany(v => v.Tags)
                .WithMany(t => t.Videos)
                .Map(m =>
                {
                    m.ToTable("VideoTags");
                    m.MapLeftKey("VideoId");
                    m.MapRightKey("TagId");
                });

        }
    }
}
