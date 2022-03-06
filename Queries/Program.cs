
using System;
using System.Collections.Generic;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            #region A- LINQ SYNTAX...
            var query =
                from c in context.Courses
                where c.Name.Contains("c#")
                orderby c.Name
                select c;

            foreach (var course in query)
            {
                Console.WriteLine(course.Name);
            }

            // Restriction in LINQ syntax
            var queryRestriction =
                from c in context.Courses
                where c.Author.Id == 1
                orderby c.Level descending, c.Name
                select c;

            // Projection in LINQ syntax
            var queryProjection =
                from c in context.Courses
                where c.Author.Id == 1
                orderby c.Level descending, c.Name
                select new { Name = c.Name, Author = c.Author.Name };

            #region Grouping in LINQ syntax
            var queryGrouping =
                from c in context.Courses
                group c by c.Level
                into g
                select g;

            foreach (var group in queryGrouping)
            {
                Console.WriteLine(group.Key);

                foreach (var course in group)
                {
                    Console.WriteLine("\t{0}", course.Name);
                }
            }

            // Count in Grouping
            foreach (var group in queryGrouping)
            {
                Console.WriteLine("{0} ({1})", group.Key, group.Count());
            }
            #endregion

            #region Joining in LINQ syntax...
            // 1- Inner Join 
            var queryInnerJoin =
                from c in context.Courses
                join a in context.Authors on c.AuthorId equals a.Id
                select new { CourseName = c.Name, AuthorName = a.Name };
            // actually you don't need this query if you have navigation property (Author in Courses class)
            queryInnerJoin =
                from c in context.Courses
                select new { CourseName = c.Name, AuthorName = c.Author.Name };

            // 2- Group Join
            var queryGroupJoin =
                from a in context.Authors
                join c in context.Courses on a.Id equals c.AuthorId into g
                select new { AuthorName = a.Name, Courses = g.Count() };

            foreach (var x in queryGroupJoin)
            {
                Console.WriteLine("{0} ({1})", x.AuthorName, x.Courses);
            }

            // 3- Cross Join
            var queryCrossJoin =
                from a in context.Authors
                from c in context.Courses
                select new { AuthorName = a.Name, CourseName = c.Name };

            foreach (var x in queryCrossJoin)
            {
                Console.WriteLine("{0} - {1}", x.AuthorName, x.CourseName);
            }
            #endregion

            #endregion

            #region B- LINQ EXTENSION METHODS...
            var courses = context.Courses
                .Where(c => c.Name.Contains("c#"))
                .OrderBy(c => c.Name);

            foreach (var course in courses)
            {
                Console.WriteLine(course.Name);
            }

            // Restriction in LINQ Extension methods...
            var coursesRestriction = context.Courses
                .Where(c => c.Level == 1)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level);

            #region Projection in LINQ Extension methods...

            var coursesProjection = context.Courses
                .Where(c => c.Level == 1)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level)
                .Select(c => new { CourseName = c.Name, AuthorName = c.Author.Name });

            // Projection "Select Many"
            // If the target property is a list (Tags) you would get a list of list
            // use SelectMany instead of Select
            var tagsProjectionSelectMany = context.Courses
                .Where(c => c.Level == 1)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level)
                .SelectMany(c => c.Tags)
                .Distinct();

            // before SelectMany
            //foreach (var c in coursesProjectionSelectMany)
            //{
            //    foreach (var tag in c)
            //    {
            //        Console.WriteLine(tag.Name);
            //    }
            //}

            // after SelectMany
            foreach (var tag in tagsProjectionSelectMany)
            {
                Console.WriteLine(tag.Name);
            }
            #endregion

            // Grouping in LINQ Extension methods
            var coursesGrouping = context.Courses.GroupBy(c => c.Level);

            foreach (var group in coursesGrouping)
            {
                Console.WriteLine("Key: "+ group.Key);

                foreach (var course in group) 
                    Console.WriteLine("\t" + course.Name);
            }

            #region Joins in LINQ Extension methods...
            // Inner Join
            var courseInnerJoin= 
                context.Courses.Join(context.Authors,
                c => c.AuthorId,
                a => a.Id,
                (course, author) => new
                {
                    CourseName = course.Name,
                    AuthorName = author.Name
                });

            // Group Join
            var authorGroupJoin =
                context.Authors.GroupJoin(context.Courses, 
                    a => a.Id, 
                    c => c.AuthorId, 
                    (author, courses2) => new
                    {
                        Author = author,
                        Courses = courses2.Count()
                    });

            // Cross Join
            var authorCrossJoin =
                context.Authors.SelectMany(
                    a => context.Courses, 
                    (author, course) => new
                    {
                        AuthorName=author.Name,
                        CourseName=course.Name
                    });

            #endregion

            // Partitioning in LINQ Extension methods
            var coursesPartitioning = context.Courses.Skip(10).Take(10);

            // Element Operators in LINQ Extension methods
            context.Courses.OrderBy(c => c.Level).FirstOrDefault(c => c.FullPrice > 100);
            context.Courses.SingleOrDefault(c => c.Id == 1);

            // Quantifying in LINQ Extension methods
            var allAbove10Dollars = context.Courses.All(c => c.FullPrice > 10);
            context.Courses.Any(c => c.Level == 1);

            // Aggregating - Singleton Value
            var count=context.Courses.Count(c=>c.Level==1);
            count = context.Courses.Where(c => c.Level == 1).Count();
            context.Courses.Max(c => c.FullPrice);
            context.Courses.Min(c => c.FullPrice);
            context.Courses.Average(c => c.FullPrice);

            // Deferred Execution in LINQ Extension methods
            // query execution is deferred until
            // - Iterating
            // - ToList(), ToArray, ToDictionary
            // - First(), Last, Single, Count, Max, Min, Average
            var coursesDefered = 
                context.Courses
                .ToList().Where(c => c.IsBeginnerCourse == true);

            foreach (var course in coursesDefered)
            {
                Console.WriteLine(course.Name);
            }
            
            // IQueryable - extend queries
            // with IQueryable, query works after filtering
            // with IEnumerable, query works immediately without filtering

            // IEnumerable<Course> courses3 = context.Courses;
            IQueryable<Course> courses3 = context.Courses;
            var filtered = courses3.Where(c => c.Level == 1);
            foreach (var c in filtered)
            {
                Console.WriteLine(c.Name);
            }

            #endregion





        }
    }
}
