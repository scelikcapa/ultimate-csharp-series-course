using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkNET.CodeFirstDemo
{
    // 8.DEMO: CODE-FIRST WORKFLOW
    public class CodeFirstPost
    {
        public int Id { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class BlogDbContext : DbContext
    {
        public DbSet<CodeFirstPost> Posts { get; set; }
    }
}
