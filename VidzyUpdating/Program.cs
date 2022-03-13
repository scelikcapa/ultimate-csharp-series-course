using System;
using System.Data.Entity;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            // ENTITY FRAMEWORK SECTION 8: UPDATING DATA EXERCSES

            // 1-
            AddVideoToVideosTable("Terminator 1", 2, new DateTime(1984, 10, 26), Classification.Silver);

            // 2-
            AddTagToTagsTable("classics");
            AddTagToTagsTable("drama");

            // Mosh Solution
            // Exercise 2: Add two tags "classics" and "drama" to the database.
            AddTags("classics", "drama");

            // 3-
            AddTagToVideo(1, "classics");
            AddTagToVideo(1, "drama");
            AddTagToVideo(1, "comedy");

            // 4-
            RemoveTagFromVideo(1, "comedy"); // nothing happens if there is no tag with this name

            // 5-
            RemoveVideoFromVideosTable(1);

            // 6-
            RemoveGenreWithCourses(2);

        }

        public static void RemoveGenreWithCourses(byte genreId)
        {
            using (var context = new VidzyContext())
            {
                var videos = context.Videos.Where(v => v.GenreId == genreId);

                context.Videos.RemoveRange(videos);
                var genre = context.Genres.Find(genreId);
                
                if (genre != null) 
                    context.Genres.Remove(genre);
                
                context.SaveChanges();
            }
        }
        // Mosh Solution
        public static void RemoveGenre(int genreId, bool enforceDeletingVideos)
        {
            using (var context = new VidzyContext())
            {
                var genre = context.Genres.Include(g => g.Videos).SingleOrDefault(g => g.Id == genreId);
                if (genre == null) return;

                if (enforceDeletingVideos)
                    context.Videos.RemoveRange(genre.Videos);

                context.Genres.Remove(genre);
                context.SaveChanges();
            }
        }


        public static void RemoveVideoFromVideosTable(byte videoId)
        {
            using (var context = new VidzyContext())
            {
                var video = context.Videos.Find(videoId);
                if (video == null) return;

                context.Videos.Remove(video);
                context.SaveChanges();
            }
        }


        public static void RemoveTagFromVideo(byte videoId, string tagName)
        {
            using (var context = new VidzyContext())
            {
                context.Videos.Find(videoId).RemoveTag(tagName);
                context.SaveChanges();
            }
        }
        // Mosh Solution
        public static void RemoveTagsFromVideo(int videoId, params string[] tagNames)
        {
            using (var context = new VidzyContext())
            {
                // We can use explicit loading to only load tags that we're going to delete.
                context.Tags.Where(t => tagNames.Contains(t.Name)).Load();

                var video = context.Videos.Single(v => v.Id == videoId);

                foreach (var tagName in tagNames)
                {
                    // I've encapsulated the concept of removing a tag inside the Video class. 
                    // This is the object-oriented way to implement this. The Video class
                    // should be responsible for adding/removing objects to its Tags collection. 
                    video.RemoveTag(tagName);
                }

                context.SaveChanges();
            }
        }


        public static void AddTagToVideo(byte videoId, string tagName)
        {
            using (var context = new VidzyContext())
            {
                AddTagToTagsTable(tagName);

                var videoTags = context.Videos.Find(videoId).Tags;

                if (!videoTags.Select(t => t.Name).Contains(tagName))
                {
                    videoTags.Add(context.Tags.Single(t => t.Name == tagName));
                    context.SaveChanges();
                }
            }
        }
        // Mosh Solution
        public static void AddTagsToVideo(int videoId, params string[] tagNames)
        {
            using (var context = new VidzyContext())
            {
                // This technique with LINQ leads to 
                // 
                // SELECT FROM Tags WHERE Name IN ('classics', 'drama')
                var tags = context.Tags.Where(t => tagNames.Contains(t.Name)).ToList();

                // So, first we load tags with the given names from the database 
                // to ensure we won't duplicate them. Now, we loop through the list of
                // tag names, and if we don't have such a tag in the database, we add
                // them to the list.
                foreach (var tagName in tagNames)
                {
                    if (!tags.Any(t => t.Name.Equals(tagName, StringComparison.CurrentCultureIgnoreCase)))
                        tags.Add(new Tag { Name = tagName });
                }

                var video = context.Videos.Single(v => v.Id == videoId);

                tags.ForEach(t => video.AddTag(t));

                context.SaveChanges();
            }
        }


        public static void AddTagToTagsTable(string name)
        {
            using (var context = new VidzyContext())
            {
                if (!context.Tags.Select(t => t.Name).ToList().Contains(name))
                {
                    context.Tags.Add(new Tag {Name = name});
                    context.SaveChanges();
                }
            }
        }
        // Mosh Solution
        public static void AddTags(params string[] tagNames)
        {
            using (var context = new VidzyContext())
            {
                // We load the tags with the given names first, to prevent adding duplicates.
                var tags = context.Tags.Where(t => tagNames.Contains(t.Name)).ToList();

                foreach (var name in tagNames)
                {
                    if (!tags.Any(t => t.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
                        context.Tags.Add(new Tag { Name = name });
                }

                context.SaveChanges();
            }
        }


        public static void AddVideoToVideosTable(string name, byte genreId, DateTime releaseDate,
            Classification classification)
        {
            using (var context = new VidzyContext())
            {
                context.Videos.Add(new Video
                {
                    Name = name,
                    GenreId = genreId,
                    ReleaseDate = releaseDate,
                    Classification = classification
                });

                context.SaveChanges();
            }
        }
    }
}