using System;

namespace CSharpAdvanceNET.Delegates
{
    public class PhotoProcessor
    {
        // delegates have to have same signature (return type and parameters) with the method it handles
        // you can use generic handlers instead of own creation handler
        public delegate void PhotoFilterHandler(Photo photo);

        // Two generic delegates in .NET Framework
        // System.Action<> does not return value
        // System.Func<> returns a value


        //public void Process(string path)
        //{
        //    var photo = Photo.Load(path);

        //    var filters = new PhotoFilters();
        //    filters.ApplyBrightness(photo);
        //    filters.ApplyContrast(photo);
        //    filters.Resize(photo);

        //    photo.Save();
        //}


        public void Process(string path,Action<Photo> filterHandler)
        {
            var photo = Photo.Load(path);

            filterHandler(photo);

            photo.Save();
        }





    }
}