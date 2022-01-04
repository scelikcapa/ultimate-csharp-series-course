using System;

namespace CSharpIntermediate.ExercisesWorkFlowEngine
{
    public interface IActivity
    {
        void Execute();
    }

    public class ConsoleActivity : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Console activity started...");
        }
    }
    public class FileActivity : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("File activity started...");
        }
    }
    public class DatabaseActivity : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Database activity started...");
        }
    }
}