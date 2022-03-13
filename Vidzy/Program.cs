using System;
using System.Data.Entity;
using System.Linq;

namespace VidzyFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            // ENTITY FRAMEWORK SECTION 6 EXERCISES

            var context = new VidzyFirstContext();

            // Action movies sorted by name
            var sortedActionMovies = context.Videos
                .Where(v => v.Genre.Name == "Action")
                .OrderBy(v => v.Name);

            foreach (var movie in sortedActionMovies)
            {
                Console.WriteLine(movie.Name);
            }

            // Gold drama movies sorted by release date (newest first)
            var sortedGoldDramaMovies = context.Videos
                .Where(v => v.Genre.Name == "Drama")
                .OrderByDescending(v => v.ReleaseDate);

            foreach (var movie in sortedGoldDramaMovies)
            {
                Console.WriteLine(movie.Name);
            }

            // All movies projected into an anonymous type with two properties:MovieName and Genre
            var allProjected = context.Videos
                .Select(v => new {MovieName = v.Name, Genre = v.Genre});

            foreach (var movie in allProjected)
            {
                Console.WriteLine("MovieName: {0} - Genre: {1}",movie.MovieName,movie.Genre);
            }

            // All movies grouped by their classification
            var groupedClassification = context.Videos
                .GroupBy(v => v.Classification)
                .Select(v => new
                {
                    Classification = v.Key,
                    Movies = v.OrderBy(m=>m.Name)
                });

            foreach (var group in groupedClassification)
            {
                Console.WriteLine(group.Classification);

                foreach (var video in group.Movies)
                {
                    Console.WriteLine("\t"+video.Name);
                }
            }

            // List of classifications sorted alphabetically and count of videos in them.
            var countedClassification = context.Videos
                .GroupBy(v => v.Classification)
                .OrderBy(g=>g.Key.ToString());

            foreach (var group in countedClassification)
            {
                Console.WriteLine("{0} ({1})",group.Key,group.Count());
            }

            // List of genres and number of videos they include, sorted by the number of videos. 
            var countedGenres = context.Genres
                .GroupJoin(context.Videos,
                    g=>g.Id,
                    v=>v.GenreId,
                    (genre,video)=>new
                    {
                        Genre=genre.Name,
                        VideoCount=video.Count()
                    })
                .OrderByDescending(x => x.VideoCount);

            foreach (var group in countedGenres)
            {
                Console.WriteLine("{0} ({1})",group.Genre,group.VideoCount);
            }

               
            // ENTITY FRAMEWORK SECTION 7 EXERCISES: Loading Related Object

            // Eager Loading with lambda expression: Include(v=>v.Genre)
            var videos = context.Videos.Include(v => v.Genre).ToList();

            foreach (var video in videos)
            {
                Console.WriteLine("Video Name: " + video.Name + " - Video Genre: " + video.Genre.Name);
            }

            // Explicit Loading with Mosh way
            var genres = context.Genres.ToList();
            var genreIds = genres.Select(g => g.Id);

            var videosExplicit = context.Videos.Where(v => genreIds.Contains(v.GenreId));

            foreach (var video in videosExplicit)
            {
                Console.WriteLine("Video Name: " + video.Name + " - Video Genre: " + video.Genre.Name);
            }

        }
    }
}
