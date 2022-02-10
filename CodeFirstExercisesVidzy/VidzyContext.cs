using System.Data.Entity;

namespace CodeFirstExercisesVidzy
{
    public class VidzyContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}