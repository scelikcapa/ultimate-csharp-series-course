using System;

namespace CSharpIntermediate.Methods
{
    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Move(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Move(Point newLocation)
        {
            // METHOD OVERLOADING

            // this.X = newLocation.X;
            // this.Y = newLocation.Y;
            if (newLocation == null)
                throw new ArgumentNullException("newLocation");

            Move(newLocation.X,newLocation.Y);
        }
    }
}