using System;

namespace CSharpIntermediate.ExercisesPolymorphism
{
    public class DbCommand
    {
        private string _instruction;
        public string Instruction
        {
            get
            {
                return _instruction;
            }
            private set
            {
                _instruction = value ?? throw new NotImplementedException("Instruction cannot be null");
            }
        }

        private DbConnection _connection;
        public DbConnection Connection
        {
            get => _connection;
            private set => _connection = value ?? throw new NotImplementedException("DbConnection cannot be null");
        }

        public DbCommand(DbConnection connection, string instruction)
        {
            Instruction = instruction;
            Connection = connection;
        }

        public void Execute()
        { 
            Connection.OpenConnection();

            Console.WriteLine("Running the instruction: "+Instruction);

            Connection.CloseConnection();
        }

    }
}