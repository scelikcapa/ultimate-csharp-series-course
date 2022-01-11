namespace CSharpAdvanceNET.Generic
{
    // 5 Types of Constraints
    // where T : IComparable
    // where T : Product
    // where T : struct
    // where T : class
    // where T : new()

    public class Nullable<T> where T : struct
    {
        // becareful. here type of _value is "object" not "T"
        private object _value;

        public Nullable()
        {
        }

        public Nullable(T value)
        {
            _value = value;
        }

        public bool HasValue
        {
            get { return _value != null; }
        }

        public T GetValueOrDefault()
        {
            if (HasValue)
                return (T) _value;

            // default() return the default value for runtime type
            // for example if type is int then default(T) returns 0 
            return default(T);
        }

    }
}