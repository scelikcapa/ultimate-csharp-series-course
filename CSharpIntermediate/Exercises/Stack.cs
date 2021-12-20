using System;
using System.Collections.Generic;

namespace CSharpIntermediate.Exercises
{
    public class Stack
    {
        public List<object> List { get; set; }

        public Stack()
        {
            this.List = new List<object>();
        }

        public void Push(object obj)
        {
            if (obj is null)
            {
                throw new InvalidOperationException("null cannot be passed to the list");
            }
            this.List.Add(obj);
        }

        public object Pop()
        {
            if (List.Count==0)
            {
                throw new InvalidOperationException("Stack is already empty");
            }

            object returnedObject = List[^1]; // ^1: index from end expression
            List.RemoveAt(List.Count-1);
            return returnedObject;
        }

        public void Clear()
        {
            List.Clear();
        }

    }
}