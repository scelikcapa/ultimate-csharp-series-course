namespace CSharpIntermediate.AbstractClasses
{
    public abstract class ShapeAbstract
    {
        public int Width { get; set; }
        public int Height { get; set; }

        // no implementation for abstract methods
        public abstract void Draw();
    }
}