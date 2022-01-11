using System;

namespace CSharpAdvanceNET.Generic
{
    // 5 Types of Constraints
    // where T : IComparable
    // where T : Product
    // where T : struct
    // where T : class
    // where T : new()

    public class GenericUtilities<T> where T:IComparable, new()
    {
        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public void DoSomething(T value)
        {
            var obj = new T();
        }

        public T Max(T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }

    // Another way: you can store generic method in NON-Generic Class
    public class Utilities
    {
        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public T Max<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }
}