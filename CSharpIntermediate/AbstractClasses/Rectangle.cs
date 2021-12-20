using System;

namespace CSharpIntermediate.AbstractClasses
{
    public class Rectangle : ShapeAbstract
    {
        public override void Draw()
        {
            Console.WriteLine("draw a rectangle");
        }
    }
}