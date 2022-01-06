using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Amazon;
using CSharpIntermediate.Composition;
using CSharpIntermediate.Constructors;
using CSharpIntermediate.Exercises;
using CSharpIntermediate.ExercisesPolymorphism;
using CSharpIntermediate.ExercisesWorkFlowEngine;
using CSharpIntermediate.Extensibility;
using CSharpIntermediate.Fields;
using CSharpIntermediate.Indexers;
using CSharpIntermediate.MethodOverriding;
using CSharpIntermediate.Methods;
using CSharpIntermediate.ObjectInitializers;
using CSharpIntermediate.Polymorphism;
using DbMigrator = CSharpIntermediate.Extensibility.DbMigrator;
using Shape = CSharpIntermediate.Casting.Shape;
using Stack = CSharpIntermediate.Exercises.Stack;
using Text = CSharpIntermediate.Inheritance.Text;

namespace CSharpIntermediate
{
    class OldLessonIntermediate
    {
        public static void RunCodes()
        {
            // SECTION 2: CLASSES
            // BENEFITS OF STATIC MEMBER/METHODS
            // var person = new Person();
            // person.name = "Samet";
            // person.Introduce("Ahmet");

            var person = Person.Parse("Samet");
            person.Introduce("Ahmet");


            // CONSTRUCTORS
            // Default values while creating an object:
            // For Numbers: zero '0'
            // For Boolean: false
            // For String and Other Objects: null
            // For Characters: empty character ''

            var customer = new Customer(1, "john");
            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.Name);

            // In default constructor Customer(), new List<Order>() has been created already. See constructor
            // That's why we didn't get NullReferenceException with customerNew.Orders.Add(order);
            var order = new Order();
            var customer2 = new Customer();
            customer2.Orders.Add(order);


            // OBJECT INITIALIZERS
            var person2 = new Person
            {
                FirstName = "Mosh",
                LastName = "Hamedani"
            };


            // PUBLIC - PRIVATE AND ENCAPSULATION
            // var person2 = new Person();
            // person2.SetBirthDate(new DateTime(1987, 02, 22));
            // Console.WriteLine(person2.GetBirthDate());


            // INDEXERS
            var cookie = new HttpCookie();
            cookie["name"] = "Mosh";
            Console.WriteLine(cookie["name"]);


            // SECTION 3: ASSOCIATION BETWEEN CLASSES
            // INHERITANCE
            var text = new Text();
            text.FontSize = 100;
            text.Copy();


            // COMPOSITION
            var dbMigrator = new CSharpIntermediate.Composition.DbMigrator(new Logger());
            var logger = new Logger();
            var installer = new Installer(logger);

            dbMigrator.Migrate();
            installer.Install();


            // SECTION 4: INHERITANCE - SECOND PILLAR OF OOP
            // ACCESS MODIFIERS
            var customerAccess = new CustomerAccess();
            customerAccess.Promote();
            // Cannot access Internal Class outside of the Class Library (DLL)
            // Amazon.RateCalculator calculator = new RateCalculator();


            // CONSTRUCTOR AND INHERITANCE
            var car = new Car("XYZ123");


            // UPCASTING
            // Upcasting is implicit: whenever a method requires an object,
            // you can pass an object or any types that derives from that object
            StreamReader reader = new StreamReader(new MemoryStream());

            // ArrayList can hold Object type which is base fot int, string etc. 
            var list = new ArrayList();
            list.Add(1);
            list.Add("Mosh");
            list.Add(new Casting.Text());

            // Genericlist is better than arraylist. Also you can give derivated class from Shape 
            var anotherList = new List<Shape>();
            anotherList.Add(new Casting.Text());


            // DOWNCASTING
            // Downcasting is explicit, if an object gives a limited view,
            // you can downcasting to convert an object to a more specific type
            Shape shape = new Casting.Text();
            Casting.Text text2 = (Casting.Text)shape;
            text2.Width = 200;
            shape.Width = 100;
            Console.WriteLine(text2.Width);
            //See other Button example in WPF project

            // 25. BOXING AND UNBOXING
            var list2 = new ArrayList();
            list2.Add(1); // Integer is value type. There is boxing
            list2.Add("Mosh"); // String is reference type. No boxing
            list2.Add(DateTime.Today); // DateTime is structure. Structure is value type.
                                       // There is boxing

            // Use generic list where possible without boxing
            var anotherList2 = new List<int>();
            var names = new List<string>();

            
            // SECTION 5: POLYMORPHISM: THIRD PILLAR OF OOP
            // 28. METHOD OVERRIDING
            var shapes = new List<MethodOverriding.Shape>();
            shapes.Add(new Circle { Width = 100, Height = 100 });
            shapes.Add(new Rectangle());
            shapes.Add(new Triangle());

            var canvas = new Canvas();
            canvas.DrawShapes(shapes);

            // 29. ABSTRACT CLASSES AND MEMBERS
            // cannot create an instance of the abstract class
            // var shape = new ShapeAbstract(); 

            var rectangle = new AbstractClasses.Rectangle();
            rectangle.Draw();


            // 32. EXERCISES
            // Exercise 1: Design a database connection
            var oracleConnection = new OracleConnection("connection string");
            oracleConnection.OpenConnection();
            oracleConnection.CloseConnection();
            
            // If you send null or empty string than throw an exception
            var sqlConnection = new SqlConnection(null);
            sqlConnection.OpenConnection();
            sqlConnection.CloseConnection();

            // Exercise 2: Design a database command
            var dbCommand = new DbCommand(new SqlConnection("SQL connection string"), "SQL instruction");
            dbCommand.Execute();
            dbCommand = new DbCommand(new OracleConnection("Oracle connection string"), "Oracle instruction");
            dbCommand.Execute();


            // 35. INTERFACES AND EXTENSIBILITY
            var dbMigrator2 = new DbMigrator(new FileLogger(@"C:\Users\Admin\source\repos\ConsoleApp1\CSharpIntermediate\ProjectsFileOperations\log.txt"));
            dbMigrator2.Migrate();

            dbMigrator2 = new DbMigrator(new ConsoleLogger());
            dbMigrator2.Migrate();

            // 36. INTERFACES AND POLYMORPHISM
            // polymorphic behavior: calling different methods at runtime
            var encoder = new VideoEncoder();
            encoder.RegisterNotificationChannel(new MailNotificationChanel());
            encoder.RegisterNotificationChannel(new SmsNotificationChannel());
            encoder.Encode(new Video());

            // 39. EXERCISES
            var workflow = new Workflow();
            workflow.AddActivity(new ConsoleActivity());
            workflow.AddActivity(new DatabaseActivity());
            workflow.AddActivity(new FileActivity());

            var engine = new WorkflowEngine();
            engine.Run(workflow);


        }

        public static void RunExercises1()
        {
            // BOLUM-2: 16. EXERCISES 1: Design a Stopwatch
            var stopwatch = new Stopwatch();

            while (true)
            {
                Console.Write("enter key... type 's':start stopwatch | 'p':pause stopwatch | or 'exit':: ");
                var input = Console.ReadLine();
                if (input == 's'.ToString())
                    stopwatch.Start();
                else if (input == 'p'.ToString())
                {
                    stopwatch.Stop();
                    Console.WriteLine(stopwatch.LastDurationTotal.TotalSeconds);
                }
                else if(input =="exit")
                    break;
            }

            // BOLUM-2: 16. EXERCISES 2: Design a StackOverflow Post
            var post = new Post("title", "decription");
            Console.WriteLine(post.Title);
            Console.WriteLine(post.Description);
            Console.WriteLine(post.Votes);
            post.UpVote();
            post.UpVote();
            post.DownVote();
            Console.WriteLine(post.Votes);

            // BOLUM-4: 27. EXERCISES 1: Design a Stack
            var stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            // stack.Push(null);
            // stack.Pop();
        }

        public static void UseOut()
        {
            // OUT PARAMETER
            try
            {
                var num = int.Parse("abc");
            }
            catch (Exception)
            {
                Console.WriteLine("Conversion failed");
            }

            int number;
            var result = int.TryParse("abc", out number);
            if (result)
                Console.WriteLine("number");
            else
                Console.WriteLine("Conversion failed");
        }

        public static void UseParams()
        {
            // METHODS
            // Params Parameter
            var calculator = new Calculator();
            Console.WriteLine(calculator.Add(1, 2));
            Console.WriteLine(calculator.Add(1, 2, 3));
            Console.WriteLine(calculator.Add(1, 2, 3, 4));
            Console.WriteLine(calculator.Add(new int[] { 1, 2, 3, 4, 5 }));
        }
        
        public static void UsePoints()
        {

            // METHODS
            try
            {
                var point = new Point(10, 20);
                point.Move(new Point(40, 60));
                Console.WriteLine("Point is at ({0},{1})", point.X, point.Y);

                point.Move(100, 200);
                Console.WriteLine("Point is at ({0},{1})", point.X, point.Y);
            }
            catch (Exception)
            {
                Console.WriteLine("An unexpected error occured");
            }
        }
    }
}
