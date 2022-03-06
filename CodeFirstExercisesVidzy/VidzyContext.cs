using System.Data.Entity;
using CodeFirstExercisesVidzy.EntityConfigurations;

namespace CodeFirstExercisesVidzy
{
    public class VidzyContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.Configurations.Add(new VideoConfiguration());
            modelbuilder.Configurations.Add(new GenreConfiguration());

            base.OnModelCreating(modelbuilder);
        }
    }
}