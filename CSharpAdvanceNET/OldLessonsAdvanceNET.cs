using System;
using System.Collections.Generic;
using System.Linq;
using CSharpAdvanceNET.Delegates;
using CSharpAdvanceNET.EventsAndDelegates;
using CSharpAdvanceNET.ExtensionMethods;
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


            //9. EVENTS
            var video = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder(); // publisher
            var mailService = new MailService(); // subscriber
            var messageService = new MessageService(); // subscriber

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded; // no brakets!
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncoder.Encode(video);


            // 10.EXTENSION METHODS
            // this class have to be in the scope of String Class
            // class and method have to be static. but you can use it with instance. Different from regular methods
            // if base class(etc String) change and same method comes then base class method overload extension
            // use extension methods only when you really have to
            string post = "This is supposed to be a very long blog post blah blah blah...";
            var shortenedPost = post.Shorten(5);

            Console.WriteLine(shortenedPost);

            // real life examples for extension methods. Max() is an extension method in LINQ
            IEnumerable<int> numbers2 = new List<int>() { 1, 5, 3, 10, 2, 18 };
            var max = numbers2.Max();
            Console.WriteLine(max);

        }

        // using in 7.DELEGATES
        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("RemoveRedEyeFilter");
        }

    }
}