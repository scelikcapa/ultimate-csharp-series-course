using System;

namespace CSharpIntermediate.Constructors
{
    public class Vehicle
    {
        //public Vehicle()
        //{
        //    Console.WriteLine("Vehicle is being initialized.");
        //}

        public Vehicle(string registrationNumber)
        {
            Console.WriteLine("Vehicle is being initialized {0}",registrationNumber);
        }
    }
}