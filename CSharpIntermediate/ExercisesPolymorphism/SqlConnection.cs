using System;

namespace CSharpIntermediate.ExercisesPolymorphism
{
    public class SqlConnection : DbConnection
    {
        public SqlConnection(string connectionString) : base(connectionString)
        {
        }

        public override void OpenConnection()
        {
            Console.WriteLine("Sql Connection opened");
        }

        public override void CloseConnection()
        {
            Console.WriteLine("Sql Connection closed");
        }
    }
}