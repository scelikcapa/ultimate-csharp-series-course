using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CSharpFundamentals;
using CSharpFundamentals.Math;

namespace CSharpFundamentals
{
    public class OldLessons
    {
       
        public static void RunCodes()
        {
            //VARIABLES - ATTIRIBUTES
            byte oneByte1 = 255;
            short twoByte2 = +32767;
            int fourByte4 = 2100000000;
            long eightByte8 = 8999999999999999999; //8.999.999.999.999.999.999

            float heightByte4 = 1.45f;
            double heightByte8 = 2.90;
            decimal heightByte16 = 4.90m;

            char characterByte2 = 'S';
            const bool statusByte1 = true;
            string familyName = "Çelikçapa";

            var age2 = 2;
            var weight2 = 80;
            var carLenght2 = 9999999999999;
            var height2 = 1.55f;
            var character2 = 'S';
            var familyName2 = "Çelikçapa";
            var isLiveInTurkey2 = true;


            Console.WriteLine("{0} {1}", byte.MaxValue, byte.MinValue);


            //TYPE CONVERSION
            //Implicitly
            byte b1 = 1;
            int j = b1;
            //Explicitly casting
            int nbr = 1;
            byte b = (byte)nbr;
            //NON-Convertable Values - Convert Class
            var number = "1234";
            //ERROR int z = (int) number; string cannot be converted by casting
            int z = Convert.ToInt32(number);
            Console.WriteLine(z);
            Console.WriteLine(number);

            try
            {
                //
                var number2 = "4321";
                byte w = Convert.ToByte(number2);

            }
            catch (Exception exception)
            {
                Console.WriteLine("Converting with data loss is not possible");

            }

            string str = "true";
            bool yesNo = Convert.ToBoolean(str);
            Console.WriteLine(yesNo);


            //OPERATORS
            int a = 1;
            int k = a++;
            Console.WriteLine("a={0} b={1}", a, k);

            int c = 1;
            int d = ++c;
            Console.WriteLine("a={0} b={1}", c, d);

            var aa = 1;
            var bb = 2;
            var cc = 3;
            Console.WriteLine(a > b && b < c); //first, > operators will work that &&

            //STATIC MODIFIER .... when you need only single instance 
            //We can access static member directly without creating an object
            //we cannot access static member from an object!
            var samet = new Person();
            samet.FirstName = "samet";
            samet.LastName = "celikcapa";
            samet.Introduce();

            //CHANGED NAMESPACE CSharpFundamentals.Math
            Calculator calculator = new Calculator();
            var result = calculator.Add(1, 2);
            Console.WriteLine(result);


            //ARRAYS
            int[] numbers = new int[3] { 1, 2, 3 };
            //numbers[0] = 1;

            var numbersArray = new int[3];
            numbersArray[0] = 1;

            Console.WriteLine(numbersArray[0]);
            Console.WriteLine(numbersArray[1]);
            Console.WriteLine(numbersArray[2]);


            //STRINGS
            string name = string.Format("{0} {1}", samet.FirstName, samet.LastName);
            Console.WriteLine(name);

            string list = String.Join(',', new int[3] { 1, 2, 3 });
            Console.WriteLine(list);

            //string are immutable
            string nameNew = "Mosh";
            char firstChar = nameNew[0];
            // nameNew[0] = 'N'; --you cannot do that. It is read-only
            nameNew = "Nosh";
            Console.WriteLine(nameNew);
            //verbatim strings
            string path = "C:\\project\\project1\\folder1";
            string verbatimpath = @"C:\project\project1\folder1";

            Console.WriteLine(path);
            Console.WriteLine(verbatimpath);

            var firstName = "Samet";
            string lastName = "Celikcapa";
            String middleName = "Hello"; //if use Strig class directly you have to use "using System;" EXACTLY SAME...
            Int32 number1 = 4;
            int number4 = 4;

            var fullName = firstName + " " + lastName; //CONCATENATE
            var myFullName = string.Format("my name is {0} {1}", firstName, lastName);

            var names = new string[3] { "John", "Jack", "Mary" };
            var joinNames = string.Join("-", names);
            Console.WriteLine(myFullName + "\n" + joinNames);

            var text = @"Hi John

                                Look into the following paths
        c:\folder1\folder2
        c:\folder3folder4";
            Console.WriteLine(text);


            //ENUM
            var method = ShippingMethod.Express;
            Console.WriteLine((int)method);

            var methodId = 3;
            Console.WriteLine((ShippingMethod)methodId);

            //Convert enum to/from string. Every object in C# has ToString() method
            var stringEnum = method.ToString();
            //Parse the string into a ......
            var methodName = "Express";
            var parsedMethodName = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), methodName);
            Console.WriteLine(parsedMethodName);

            //REFERENCE TYPE VS VALUE TYPE
            var array1 = new int[3] { 1, 2, 3 };
            var array2 = array1;
            array2[0] = 0;
            Console.WriteLine("array1[0]: {0} array2[0]: {1}", array1[0], array2[0]);

            //Value and Reference type continue....
            //1- Value Type behavior... 
            var numberx = 1;
            Program.Increment(numberx); //value of number variable won't be 10. It is still 1.
                                //Cause copy of number variable sent to the method. Copied one will be 10 and be destroyed
                                //2- Reference Type behavior...
            var person = new Person() { Age = 20 };
            Program.MakeOld(person);
            Console.WriteLine(person.Age);


            //CONDITIONS-OPERATORS
            //If-Else
            //Conditional Operators:    ==  !=  >   >=  <   <=
            //Arithmetic Operators:     ++  --
            //Logical Operators:        &&  ||  !
            //Bitwise Op.(API-Sockets): &   |
            //Assignment Operators:     =   +=(a+=3 a=a+3)  -=  *=  /=


            int hour = 13;

            if (hour > 0 && hour < 12)
                Console.WriteLine("Morning");
            else if (hour >= 12 && hour < 18)
                Console.WriteLine("Afternoon");
            else
                Console.WriteLine("Evening");

            //Simple If-Else
            bool isGoldCustomer = true;
            float price = (isGoldCustomer) ? 19.99f : 29.99f;
            Console.WriteLine(price);

            //Switch-Case
            var season = Season.Autumn;

            switch (season)
            {
                case Season.Autumn:
                case Season.Spring:
                    Console.WriteLine("We've got promotion");
                    break;
                default:
                    Console.WriteLine("I don't understand that season");
                    break;
            }

            
            //ITERATION STATEMENTS
            //for
            for (var l = 0; l <= 10; l++)
            {
                if (l % 2 == 0)
                {
                    Console.WriteLine("for: " + l);
                }

            }

            //foreach - if there is smth "enumerable"
            var nameX = "John Smith";
            //for (int l = 0; l < nameX.Length; l++)
            //{
            //    Console.WriteLine(nameX[l]);
            //}

            foreach (var character in nameX)
            {
                Console.WriteLine("foreach: " + character);
            }

            //while - when you don't know number of iteration
            //var m = 0;
            //while (m<=10)
            //{
            //    if (m%2==0)
            //    {
            //        Console.WriteLine("while: "+m);
            //    }
            //    m++;
            //}

            //while common usage only "break;" choose the one which is more readable
            while (true)
            {
                Console.Write("type your name: ");
                var input = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                Console.WriteLine("@Echo: " + input);
            }
            //while common usage with "continue;" choose the one which is more readable
            while (true)
            {
                Console.Write("type your name: ");
                var input = Console.ReadLine();

                if (!(String.IsNullOrWhiteSpace(input)))
                {
                    Console.WriteLine("@Echo: " + input);
                    continue;
                }
                break;
            }
            //do-while: at least one time code is working!
            do
            {
                Console.Write("type your name: ");
                var input = Console.ReadLine();

                if (!(String.IsNullOrWhiteSpace(input)))
                {
                    Console.WriteLine("@Echo: " + input);
                    continue;
                }
                break;

            } while (true);

            //RANDOM
            var random = new Random();

            const int passwordLenght = 10;

            var buffer = new char[passwordLenght];
            for (int i = 0; i < passwordLenght; i++)
                buffer[i] = (char)('a' + random.Next(0, 26));

            var password = new string(buffer);
            Console.WriteLine(password);

            // ARRAYS - BÖLÜM:6 - ADVANCE COURSE
            var numbers2 = new[] { 3, 7, 9, 2, 14, 6 };

            // Rectangular Arrays
            var arrRectangular = new int[3, 5];

            // Lenght
            Console.WriteLine("Lenght: " + numbers2.Length);

            // IndexOf()
            var index = Array.IndexOf(numbers2, 9);
            Console.WriteLine("Ondex of 9: " + index);

            // Clear() - if you clear integer=0 or bool=false or string/object=null
            Array.Clear(numbers2, 0, 2);
            Console.WriteLine("Effect of Clear()");
            foreach (var n in numbers2)
            {
                Console.WriteLine(n);
            }

            // Copy()
            var another = new int[3];
            Array.Copy(numbers2, another, 3);

            Console.WriteLine("Effect of Copy()");
            foreach (var n in another)
            {
                Console.WriteLine(n);
            }

            // Sort()
            Array.Sort(numbers2);
            Console.WriteLine("Effect of Sort()");
            foreach (var n in numbers2)
            {
                Console.WriteLine(n);
            }

            // Reverse()
            Array.Reverse(numbers2);
            Console.WriteLine("Effect of Reverse()");
            foreach (var n in numbers2)
            {
                Console.WriteLine(n);
            }


            // LIST
            var numbersList = new List<int> { 1, 2, 3, 4 };

            numbersList.Add(1);
            numbersList.AddRange(new int[3] { 5, 6, 7 });

            foreach (var n in numbersList)
                Console.WriteLine(n);

            Console.WriteLine();
            Console.WriteLine("Index of 1: " + numbersList.IndexOf(1));
            Console.WriteLine("Last Index of 1: " + numbersList.LastIndexOf(1));

            Console.WriteLine("Count: " + numbersList.Count);

            //using foreach block with Remove() method, then exception will occur. For block has to be used

            //foreach (var n in numbersList)
            //{
            //    if (n==1)
            //    {
            //        numbersList.Remove(n);
            //    }   
            //}

            for (int i = 0; i < numbersList.Count; i++)
            {
                if (numbersList[i] == 1)
                {
                    numbersList.Remove(numbersList[i]);
                }
            }

            foreach (var n in numbersList)
                Console.WriteLine(n);

            numbersList.Clear();
            Console.WriteLine("Count after Clear(): " + numbersList.Count);


            //DATE AND TIME 
            var dateTime = new DateTime(2021, 10, 28);
            var now = DateTime.Now;
            var today = DateTime.Today;

            Console.WriteLine("Hour :" + now.Hour);
            Console.WriteLine("Minutes :" + now.Minute);
            Console.WriteLine();

            var tomorrow = dateTime.AddDays(1);
            var yesterday = dateTime.AddDays(-1);
            Console.WriteLine("Tomorrow: " + tomorrow.ToShortDateString());
            Console.WriteLine("Yesterday: " + yesterday.ToShortDateString());
            Console.WriteLine();

            Console.WriteLine(now.ToLongDateString());
            Console.WriteLine(now.ToShortDateString());
            Console.WriteLine();

            Console.WriteLine(now.ToLongTimeString());
            Console.WriteLine(now.ToShortTimeString());
            Console.WriteLine();

            // formatting - google: c# datetime format specifier
            Console.WriteLine(now.ToString("yy-MM-dd HH:mm"));
            Console.WriteLine();


            // TIME SPAN
            // creating
            var timeSpan = new TimeSpan(1, 2, 3);

            // same result but different writing
            var timeSpan1 = new TimeSpan(1, 0, 0);
            var timeSpan2 = TimeSpan.FromHours(1);

            var start = DateTime.Now;
            var end = DateTime.Now.AddMinutes(8);
            var duration = end - start;
            Console.WriteLine("Duration: " + duration);

            // properties
            Console.WriteLine("Minutes: " + timeSpan.Minutes);
            Console.WriteLine("Total Minutes: " + timeSpan.TotalMinutes);

            // add
            Console.WriteLine("Add Example: " + timeSpan.Add(TimeSpan.FromMinutes(8)));
            Console.WriteLine("Subtract Example: " + timeSpan.Subtract(new TimeSpan(0, 2, 0)));

            // ToString()
            Console.WriteLine("ToString(): " + timeSpan.ToString());

            // parse
            Console.WriteLine("Parse: " + TimeSpan.Parse("01:02:03"));

            // STRING
            var fullName1 = "Samet Çelikçapa ";
            Console.WriteLine("Trim(): '{0}'", fullName1.Trim());
            Console.WriteLine("ToUpper(): '{0}'", fullName1.ToUpper());

            // IndexOf() and Substring() 
            var index1 = fullName1.IndexOf(' ');
            var firstName1 = fullName1.Substring(0, index1);
            var lastName1 = fullName1.Substring(index1 + 1);
            Console.WriteLine("First Name: " + firstName1);
            Console.WriteLine("Last Name: " + lastName1);

            // Split()
            var names1 = fullName1.Split(' ');
            Console.WriteLine("First Name: " + names[0]);
            Console.WriteLine("Last Name: " + names[1]);

            // Replace()
            Console.WriteLine(fullName1.Replace("Samet", "Sammy"));


            if (!String.IsNullOrEmpty(" "))
            {
                Console.WriteLine("IsNullOrEmpty() can not catch the whitespace");
            }
            if (String.IsNullOrWhiteSpace(" "))
            {
                Console.WriteLine("IsNullOrWhiteSpace() can catch whitespace/null/empty");
            }

            // Convert.ToInt32() return Zero if the string is null or empty
            // Int.Parse() throw and exception if the string is null or empty
            var str1 = "25";
            var age = Convert.ToByte(str);
            Console.WriteLine(age);

            // formatting
            float price1 = 29.95f;
            Console.WriteLine(price.ToString("C0"));


            // SUMMARISING TEXT
            var sentence = "This is a very very very very very long text";
            string summary = StringUtility.SummerizeText(sentence);
            Console.WriteLine(summary);


            // STRING BUILDER
            //var builder = new StringBuilder("Hello World");
            //builder.AppendLine();
            //builder.Append('-', 10);
            //builder.AppendLine();
            //builder.Append("Header");
            //builder.AppendLine();
            //builder.Append('-', 10);
            //builder.Replace('-', '+');
            //builder.Remove(0, 6);
            //builder.Insert(0, new string('-', 10));

            var builder = new StringBuilder("Hello World")
                .AppendLine()
                .Append('-', 10)
                .AppendLine()
                .Append("Header")
                .AppendLine()
                .Append('-', 10)
                .Replace('-', '+')
                .Remove(0, 6)
                .Insert(0, new string('-', 10));

            Console.WriteLine(builder);
            Console.WriteLine("First Char: " + builder[0]);

            // FILE AND FILEINFO
            var filePath = @"C:\Users\Admin\OneDrive - pitools\Masaüstü\Folder\somefile.txt";
            var destinationPath = @"C:\Users\Admin\OneDrive - pitools\Masaüstü\Folder\destination\somefile_copy.txt";

            FileStream fs = File.Create(filePath);
            fs.Dispose();
            Console.WriteLine("File is created...");

            File.Copy(filePath, destinationPath, true);
            Console.WriteLine("File is copied...");

            if (File.Exists(destinationPath))
                Console.WriteLine("Copied File exists...");

            File.Delete(filePath);
            Console.WriteLine("File is deleted...");

            // Note: These codes are not working. Just to show how it can be written
            var fileInfo = new FileInfo(filePath);
            fileInfo.CopyTo("...");
            fileInfo.Delete();
            if (fileInfo.Exists)
            {
                //
            }


            // DIRECTORY AND DIRECTORYINFO
            var pathDirectory = @"C:\Users\Admin\OneDrive - pitools\Masaüstü\Folder\Created Directory";
            var pathApplication = @"C:\Users\Admin\source\repos\ConsoleApp1";

            Directory.CreateDirectory(pathDirectory);
            Console.WriteLine("Folder is created");

            var files = Directory.GetFiles(pathApplication, "*.sln",
                SearchOption.AllDirectories);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
            Console.WriteLine();

            var directories = Directory.GetDirectories(pathApplication, "*", SearchOption.AllDirectories);
            foreach (var directory in directories)
            {
                Console.WriteLine(directory);
            }

            Directory.Exists(pathApplication);

            var directoryInfo = new DirectoryInfo("...");
            directoryInfo.GetFiles();
            directoryInfo.GetDirectories();


            // PATH
            var pathConsoleApplication = @"C:\Users\Admin\source\repos\ConsoleApp1\ProgrammingWithMosh.sln";

            Console.WriteLine("GetExtensions(): " + Path.GetExtension(pathConsoleApplication));
            Console.WriteLine("GetFileName(): " + Path.GetFileName(pathConsoleApplication));
            Console.WriteLine("GetFileNameWithoutExtension(): " + Path.GetFileNameWithoutExtension(pathConsoleApplication));
            Console.WriteLine("GetDirectoryName(): " + Path.GetDirectoryName(pathConsoleApplication));


            // DEBUG
            // F9 - Breakpoint
            // F5 - Run in the debug mode
            // F5 Again - Jump to the next breakpoint
            // Shift + F5 - Stop the debug mode
            // Ctrl + Shift + F5 - Restart in the debug mode
            // Ctrl + F5 - Run without debug


            // F10 - Step Over
            // F11 - Step Into
            // Shift + F11 - Step Out

            // Debug -> Windows -> Watch
            // Debug -> Windows -> Breakpoints
            // Debug -> Windows -> Call Stack
            // Debug -> Windows -> Autos
            // Debug -> Windows -> Locals

            var numbersDebug = new List<int> { 1, 2, 3, 4, 5, 6 };
            var smallests = DebugExamples.GetSmallests(numbersDebug, 3);

            foreach (var smallest in smallests)
                Console.WriteLine(smallest);




        }


    }
}
