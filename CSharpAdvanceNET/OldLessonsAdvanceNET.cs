using System;
using CSharpAdvanceNET.Delegates;
using CSharpAdvanceNET.Generic;

namespace CSharpAdvanceNET
{
    public class OldLessonsAdvanceNET
    {
        public void Run()
        {

            // SECTION 2: C# ADVANCE TOPICS
            // 6.GENERICS
            var book = new Book { Isbn = "1111", Title = "C# Advanced" };

            //var numbers=new List();
            //numbers.Add(10);

            //var books = new BookList();
            //books.Add(new Book());

            // Generic List
            var numbers = new GenericList<int>();
            numbers.Add(10);

            var books = new GenericList<Book>();
            books.Add(new Book());

            // Dictionary
            var dictionary = new GenericDictionary<string, Book>();
            dictionary.Add("1234", new Book());

            // Constraint
            var number = new Generic.Nullable<int>();
            Console.WriteLine("Has value ?" + number.HasValue);
            Console.WriteLine("Value: " + number.GetValueOrDefault());


            // 7.DELEGATES
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();

            // Normally have to pass new Photo() to filters.ApplyBrightness(Photo photo)
            // But with delegates, you don't have to because processor.Process() doing this

            // PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            // Can use generic handlers instead of yours
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += filters.Resize;
            filterHandler += RemoveRedEyeFilter;

            processor.Process("photo.jpg", filterHandler);
            
        }
        
        // using in 7.DELEGATES
        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("RemoveRedEyeFilter");
        }

    }
}