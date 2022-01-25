using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpAdvanceNET.Delegates;
using CSharpAdvanceNET.EventsAndDelegates;
using CSharpAdvanceNET.ExceptionHandling;
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


            // 11.LINQ
            var books3 = new Linq.BookRepository().GetBooks();
            //var cheapBooks = new List<Book>();
            //foreach (var book in books)
            //{
            //    if (book.Price <10)
            //        cheapBooks.Add(book);
            //}

            // LINQ Query Operators
            // always "from" is first query and "select" is last query
            var cheaperBooks =
                from b in books3
                where b.Price < 10
                orderby b.Title
                select b.Title;

            // LINQ Extension Methods
            // Where - Orderby - Select
            var cheapBooks2 = books3
                                                .Where(b => b.Price < 10)
                                                .OrderBy(b => b.Title)
                                                .Select(b => b.Title);

            foreach (var book2 in cheapBooks)
            {
                //Console.WriteLine(book.Title+" "+book.Price);
                Console.WriteLine(book2);
            }

            // Single
            // SingleOrDefault
            var bookSingle = books3.SingleOrDefault(b => b.Title == "ASP.NET MVC++");
            Console.WriteLine(bookSingle == null);
            // First
            // FirstOrDefault
            var bookFirst = books3.FirstOrDefault(b => b.Title == "C# Advanced Topics");
            Console.WriteLine(bookFirst.Title + " " + bookFirst.Price);
            // Last
            // LastOrDefault
            var bookLast = books3.LastOrDefault(b => b.Title == "C# Advanced Topics");
            Console.WriteLine(bookLast.Title + " " + bookLast.Price);
            // Skip
            // Take
            var pagedBooks = books3.Skip(2).Take(3);
            foreach (var pagedBook in pagedBooks)
            {
                Console.WriteLine(pagedBook.Title);
            }
            // Count
            var count = books3.Count();
            Console.WriteLine(count);
            // Max
            // Min
            var maxPrice = books3.Max(b => b.Price);
            var minPrice = books3.Min(b => b.Price);
            Console.WriteLine(minPrice);
            Console.WriteLine(maxPrice);
            // Sum
            var totalPrice = books3.Sum(b => b.Price);
            Console.WriteLine(totalPrice);
            // Average
            var averagePrice = books3.Average(b => b.Price);
            Console.WriteLine(averagePrice);


            // 12.NULLABLE TYPES
            // System.Nullable<DateTime> date = null;
            DateTime? date = null;
            Console.WriteLine("GetValueOrDefault(): " + date.GetValueOrDefault());
            Console.WriteLine("HasValue: " + date.HasValue);
            // Console.WriteLine("Value: "+date.Value); // exception here

            // cannot convert DateTime?(Nullable) to DateTime, use GetValueOrDefault() 
            date = new DateTime(2014, 1, 1);
            DateTime date2 = date.GetValueOrDefault();
            // can convert DateTime to DateTime?(Nullable)
            DateTime? date3 = date2;

            // Null Coalescing Operator
            date = null;
            //if (date != null)
            //    date2 = date.GetValueOrDefault();
            //else
            //    date2=DateTime.Today;
            date2 = date ?? DateTime.Today; // Null Coalescing Operator
            date2 = (date != null) ? date.GetValueOrDefault() : DateTime.Today; // Ternary Operator
            Console.WriteLine(date2);


            // 13.DYNAMIC
            // without dynamic, reflection needed. here is an example
            object obj = "Mosh";
            // assume that obj.GetHashCode() is an runtime method. than you have to do reflection
            var methodInfo = obj.GetType().GetMethod("GetHashCode");
            methodInfo.Invoke(null, null);
            // with dynamic, dont have to use reflection
            dynamic excelObject = "mosh";
            excelObject.Optimize();


            // dynamic type can be change at runtime
            dynamic name = "Mosh";
            name = 10;

            dynamic a2 = 10;
            dynamic b2 = 5;
            var c = a2 + b2;

            // implicit conversion
            int i2 = 5;
            dynamic d = i2;
            long lNumber = d;


            // 14.EXCEPTION HANDLING
            try
            {
                var calculator = new Calculator();
                var result2 = calculator.Divide(5, 0);
            }
            //catch (DivideByZeroException ex)
            //{
            //    Console.WriteLine("You cannot divide by 0.");
            //}
            //catch (ArithmeticException ex)
            //{
            //}
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, an unexpected error occured.");
            }

            // Unmanaged Resources: files, datebase, network connections, graphic handles
            // Using keyword: no need finally block
            // StreamReader streamReader=null;
            try
            {
                using (var streamReader = new StreamReader(@"c:\file.zip"))
                {
                    var content = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry, an unexpected error occured.");
            }
            //finally
            //{
            //    if (streamReader!=null)
            //        streamReader.Dispose();
            //}

            try
            {
                var api = new YouTubeApi();
                var videos = api.GetVideos("mosh");
            }
            catch (Exception ex)
            {
                Console.WriteLine("YouTubeException Message:\n" + ex.Message);
                Console.WriteLine("\nYouTubeException Source (namespace):\n" + ex.Source);
                Console.WriteLine("\nYouTubeException StackTrace:\n" + ex.StackTrace);
                Console.WriteLine("\nInnerException Message:\n" + ex.InnerException.Message);
                Console.WriteLine("\nInnerException Source (namespace):\n" + ex.InnerException.Source);
            }
        }

        // using in 7.DELEGATES
        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("RemoveRedEyeFilter");
        }

    }
}