using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkNET
{
    class Program
    {
        static void Main(string[] args)
        {
            // SECTION 2: 7.DEMO DATABASE-FIRST WORKFLOW
            var context = new DatabaseFirstDemoEntities();
            var post = new Post
            {
                PostID = 1,
                DatePublished = DateTime.Now,
                Title = "Title",
                Body = "Body"
            };
            context.Posts.Add(post);
            context.SaveChanges();
        }
    }
}
