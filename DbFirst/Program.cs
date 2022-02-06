using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirst
{
    public enum Level : byte
    {
        Beginner=1,
        Intermediate=2,
        Advanced=3
    }

    class Program
    {
        static void Main(string[] args)
        {

            // 17. IMPORTING STORED PROCEDURES 
            var context = new PlutoDbContext();
            var courses = context.GetCourses();

            foreach (var c in courses)
            {
                Console.WriteLine(c.Title);
            }


            // 19. WORKING WITH ENUMS
            var course = new Course();
            // course.Level = CourseLevel.Beginner; // 1
            course.Level = Level.Beginner;
            
        }
    }
}
