using System;

namespace CSharpIntermediate.ExercisesPolymorphism
{
    public abstract class DbConnection
    {
        private string _connectionString;
        public string ConnectionString
        {
            get => _connectionString;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new NotImplementedException("Connection String bos olamaz");
                _connectionString = value;
            }
        }

        public TimeSpan Timeout { get; set; }

        public DbConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public abstract void OpenConnection();
        public abstract void CloseConnection();
    }
}