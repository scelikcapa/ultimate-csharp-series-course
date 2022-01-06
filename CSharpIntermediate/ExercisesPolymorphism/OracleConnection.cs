using System;

namespace CSharpIntermediate.ExercisesPolymorphism
{
    public class OracleConnection:DbConnection
    {
        public OracleConnection(string connectionString) : base(connectionString)
        {
        }

        public override void OpenConnection()
        {
            Console.WriteLine("Oracle Connection opened");
        }

        public override void CloseConnection()
        {
            Console.WriteLine("Oracle Connection closed");
        }
    }
}