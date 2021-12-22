using System;

namespace CSharpIntermediate.Exercises
{
    public class Post
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Created { get; }
        public int Votes { get; private set; }

        public Post(string title,string description)
        {
            this.Title = title;
            this.Description = description;
            this.Created = DateTime.Now;
            this.Votes = 0;
        }

        public void UpVote()
        {
            this.Votes += 1;
        }

        public void DownVote()
        {
            this.Votes -= 1;
        }
    }
}