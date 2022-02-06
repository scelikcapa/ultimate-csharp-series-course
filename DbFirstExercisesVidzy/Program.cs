using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstExercisesVidzy
{
    public enum Classification:byte
    {
        Silver=1,
        Gold=2,
        Platinum=3
    }
    class Program
    {
        static void Main(string[] args)
        {

            var context = new VidzyContext();
            //context.AddVideo("VideoTitle", DateTime.Now, "Action");
            //context.SaveChanges();

            //context.AddVideo("VideoTitle2", DateTime.Now, "Horror");
            //context.AddVideo("VideoTitle3", DateTime.Now, "Family");
            //context.AddVideo("VideoTitle4", DateTime.Now, "Romance");
            context.AddVideo("VideoTitle5", DateTime.Now, "Thriller",Classification.Platinum);

            context.SaveChanges();


        }
    }
}
