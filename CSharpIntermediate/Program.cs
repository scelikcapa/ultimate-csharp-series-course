using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Transactions;
using Amazon;
using CSharpIntermediate.AbstractClasses;
using CSharpIntermediate.Casting;
using CSharpIntermediate.Composition;
using CSharpIntermediate.Constructors;
using CSharpIntermediate.Exercises;
using CSharpIntermediate.Indexers;
using CSharpIntermediate.Inheritance;
using CSharpIntermediate.MethodOverriding;
using CSharpIntermediate.Methods;
using CSharpIntermediate.Testability;
using Exception = System.Exception;
using Stack = CSharpIntermediate.Exercises.Stack;
using Text = CSharpIntermediate.Casting.Text;

namespace CSharpIntermediate
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderProcessor = new OrderProcessor(new ShippingCalculator());
            var order = new Order {DatePlaced = DateTime.Now, TotalPrice = 100f};
            orderProcessor.Process(order);
        }
    }
}
