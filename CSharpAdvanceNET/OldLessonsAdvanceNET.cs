using System;
using CSharpAdvanceNET.Delegates;
using CSharpAdvanceNET.Generic;
using CSharpAdvanceNET.LambdaExpressions;

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

            // 8.LAMBDA EXPRESSIONS
            // extra Square method needed without lambda expressions
            // Func<int, int> square = Square;
            // Console.WriteLine(Square(5));
            Func<int, int> square = number2 => number2 * number2;
            Console.WriteLine(square(5));

            //static int Square(int number)
            //{
            //    return number * number;
            //}

            // with lambda expressions, dont have to extra method
            // have to use delegates to work with lambda expressions
            // args => expression
            // nor args.... () => ....
            // one args.... x => ....
            // (x,y,z) => ....
            // number => number*number;

            const int factor = 5;
            Func<int, int> multipler = n => n * factor;
            var result = multipler(10);
            Console.WriteLine(result);

            // Common way to Use Lambda : where need Predicate Delegate
            var books2 = new BookRepository().GetBooks();
            // var cheapBooks = books.FindAll(IsCheaperThan10Dollars);
            var cheapBooks = books2.FindAll(b => b.Price < 10);
            foreach (var book2 in cheapBooks)
            {
                Console.WriteLine(book2.Title);
            }

            //static bool IsCheaperThan10Dollars(Book book)
            //{
            //    return book.Price < 10;
            //}

            
        }

        // using in 7.DELEGATES
        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("RemoveRedEyeFilter");
        }

    }
}