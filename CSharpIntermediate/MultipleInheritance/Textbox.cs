using System;

namespace CSharpIntermediate.MultipleInheritance
{
    public class Textbox : UiControl, IDraggable, IDroppable
    {
        public void Drag()
        {
            throw new NotImplementedException();
        }

        public void Drop()
        {
            throw new NotImplementedException();
        }
    }
}