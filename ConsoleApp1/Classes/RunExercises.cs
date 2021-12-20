using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Transactions;
using System.Xml;
using System.Xml.Schema;
using Microsoft.VisualBasic;

namespace CSharpFundamentals
{
    public class RunExercises
    {
        //CONDITIONS-OPERATORS
        //If-Else
        //Conditional Operators:    ==  !=  >   >=  <   <=
        //Arithmetic Operators:     ++  --
        //Logical Operators:        &&  ||  !
        //Bitwise Op.(API-Sockets): &   |
        //Assignment Operators:     =   +=(a+=3 a=a+3)  -=  *=  /=

        public static void RunMain(int runNumber, int exerciseNo)
        {
            switch (runNumber)
                {
                    case 1:
                        //EXERCISES-1: Section-5 43.Exercises
                        Run1(Convert.ToInt32(exerciseNo));
                        break;
                    case 2:
                        //EXERCISES-2: Section-5 49.Exercises
                        Run2(Convert.ToInt32(exerciseNo));
                        break;
                    case 3:
                        //EXERCISES-3: Section-6 56.Exercises
                        Run3(Convert.ToInt32(exerciseNo));
                        break;
                    case 4:
                        //EXERCISES-4: Section-8: 68.Exercises
                        Run4(Convert.ToInt32(exerciseNo));
                        break;
                    case 5:
                        //EXERCISES-5: Section-9: 76.Exercises
                        Run5();
                        break;
                    default:
                        Console.WriteLine("This RunNumber doesn't exist");
                        break;
                }
        }

        public static void Run1(int exerciseNo)
        {
            switch (exerciseNo)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("Please enter number between 1 and 10");


                    int number = Convert.ToInt32(Console.ReadLine());

                    if (number > 1 && number < 10)
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine("Invalid");
                    }
                    break;
                case 2:
                    var numbers = new int[2];
                    Console.WriteLine("Enter the first number");
                    numbers[0] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the second number");
                    numbers[1] = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Max value is: "+numbers.Max());

                    //MOSH SOLUTION
                    //Console.Write("Enter a number: ");
                    //var number1 = Convert.ToInt32(Console.ReadLine());

                    //Console.Write("Enter another number: ");
                    //var number2 = Convert.ToInt32(Console.ReadLine());

                    //var max = (number1 > number2) ? number1 : number2;
                    //Console.WriteLine("Max is " + max);


                    break;
                case 3:
                    Console.WriteLine("Enter the width");
                    int number1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the height");
                    int number2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine((number1>number2)?"landscape":"portrait");
                    break;
                case 4:
                    Console.WriteLine("Enter the speed limit");
                    int speedLimit = Convert. ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the speed of the car");
                    int carSpeed = Convert.ToInt32(Console.ReadLine());
                    if (carSpeed<speedLimit)
                        Console.WriteLine("OK");
                    else if (carSpeed>speedLimit)
                    {
                        int demeritPoints = (carSpeed - speedLimit) / 5;
                        Console.WriteLine(demeritPoints<=12?demeritPoints.ToString():"License Suspended");
                    }
                    break;
                   
                        
                    
            }





        }

        public static void Run2(int exerciseNo)
        {
            switch (exerciseNo)
            {
                case 1: 
                    var count=0;
                    
                    for (int i = 1; i <=100; i++)
                    {
                        if (i%3==0)
                        {
                            count++;
                        }
                    }

                    Console.WriteLine(count);
                    break;
                case 2:
                    var sumIntegers = 0;
                    while (true)
                    {
                        Console.WriteLine("Enter a number or press Enter to calculate the sum");
                        var inputNumber2 = Console.ReadLine();

                        if (String.Equals("ok", inputNumber2))
                        {
                            break;
                        }
                        
                        sumIntegers += Convert.ToInt32(inputNumber2);
                        
                    }
                    Console.WriteLine("Sum of all numbers is: "+ sumIntegers);
                    break;
                case 3:
                    Console.WriteLine("enter a number to compute the factorial of this number");
                    var inputNumber3 = Convert.ToInt32(Console.ReadLine());
                    int factorialResult = 1;
                    for (int i = 2; i <= inputNumber3; i++)
                    {
                        factorialResult *= i;
                    }
                    Console.WriteLine("{0}! = {1}", inputNumber3,factorialResult);
                    break;
                case 4:
                    //Random random = new Random();
                    //var randomNumber = random.Next(1, 10);
                    var randomNumber = new Random().Next(1, 10);


                    Console.WriteLine("Guess the secret number that is between 1 and 10...Tip: Secret number is: "+randomNumber);
                    for (int i = 0; i < 4; i++)
                    {
                        if (randomNumber == Convert.ToInt32(Console.ReadLine()))
                        {
                            Console.WriteLine("You won");
                            return;
                        }
                    }
                    Console.WriteLine("You lost");
                    break;
                case 5:

                   //Use the GetNumericValue methods to convert a Char object that represents a number to a numeric value type.
                   //Use Parse and TryParse to convert a character in a string into a Int/Char etc.
                   //Use ToString to convert a Char object to a String object.
                   //String Convert.Int32() ile integer yapılabilir. Ancak Char'ı aynı method ile convert, ASCII değerini verir.

                   Console.WriteLine("enter a series of numbers separated by comma. Ex: 5, 3, 8, 1, 4");
                    var series = Console.ReadLine();
                    var seriesInt = new int[series.Length];

                    
                    for (int i = 0; i < seriesInt.Length; i++)
                    {
                        if (Char.IsDigit(series[i]))
                        {
                            seriesInt[i] =Int32.Parse(series[i].ToString());
                        }
                       
                    }
                    Console.WriteLine("Max value is: "+ seriesInt.Max());

                   //MOSH SOLUTION
                   //Console.Write("Enter comma separated numbers: ");
                   //var input = Console.ReadLine();

                   //var numbers = input.Split(',');

                   //// Assume the first number is the max 
                   //var max = Convert.ToInt32(numbers[0]);

                   //foreach (var str in numbers)
                   //{
                   //    var number = Convert.ToInt32(str);
                   //    if (number > max)
                   //        max = number;
                   //}

                   //Console.WriteLine("Max is " + max);

                    break;
                default:
                    Console.WriteLine("Bu Exercises mevcut değil");
                    break;
            }
        }

        public static void Run3(int exerciseNo)
        {
            switch (exerciseNo)
            {
                case 1:
                    var friends = new List<string>();
                    
                    while (true)
                    {
                        Console.WriteLine("Please enter the user name (or hit ENTER to quit");
                        string friendName = Console.ReadLine();

                        if (String.IsNullOrWhiteSpace(friendName))
                        {
                            switch (friends.Count)
                            {
                                case 1:
                                    Console.WriteLine(friends[0] + " likes your post");
                                    break;
                                case 2:
                                    Console.WriteLine("{0} and {1} like your post", friends[0], friends[1]);
                                    break;
                                default:
                                    Console.WriteLine("{0}, {1} and {2} others like your post", friends[0], friends[1], friends.Count - 2);
                                    break;
                            }
                            break;
                        }
                        friends.Add(friendName);
                    }
                    // MOSH SOLUTION
                    //var names = new List<string>();
                    //while (true)
                    //{
                    //    Console.Write("Type a name (or hit ENTER to quit): ");

                    //    var input = Console.ReadLine();
                    //    if (String.IsNullOrWhiteSpace(input))
                    //        break;
                    //    names.Add(input);
                    //}
                    //if (names.Count > 2)
                    //    Console.WriteLine("{0}, {1} and {2} others like your post", names[0], names[1], names.Count - 2);
                    //else if (names.Count == 2)
                    //    Console.WriteLine("{0} and {1} like your post", names[0], names[1]);
                    //else if (names.Count == 1)
                    //    Console.WriteLine("{0} likes your post.", names[0]);
                    //else
                    //    Console.WriteLine();
                    break;
                
                case 2:
                    Console.WriteLine("Please enter your name");
                    var userName= Console.ReadLine();
                    var userNameArray = userName.ToCharArray();
                    Array.Reverse(userNameArray);
                    var reversedUserName = new string(userNameArray);
                    Console.WriteLine("Reversed Name: "+reversedUserName);
                    break;
                
                case 3:
                    Console.WriteLine("Enter 5 different numbers");
                    //var fiveNumbers = new int[5];
                    var fiveNumbers = new List<int>();
                    
                    for (int i=0;i<5;i++)
                    {
                        int number;
                        while (true)
                        {
                            Console.Write("Enter number-{0}: ",i+1);
                            number= Convert.ToInt32(Console.ReadLine());

                            if (fiveNumbers.IndexOf(number)>=0)
                            {
                                Console.WriteLine("Error, same number, please re-try");
                                continue;
                            }
                            break;
                        }
                        //aşağıdaki kodu while loop sonucunda sadece 1 kere çalıştıracaksan, while içinde durmasına gerek yok
                        fiveNumbers.Add(number);
                    }
                    fiveNumbers.Sort();
                    foreach (var number in fiveNumbers)
                        Console.WriteLine(number);

                    // MOSH SOLUTION
                    //var numbers = new List<int>();

                    //while (numbers.Count < 5)
                    //{
                    //    Console.Write("Enter a number: ");
                    //    var number = Convert.ToInt32(Console.ReadLine());
                    //    if (numbers.Contains(number))
                    //    {
                    //        Console.WriteLine("You've previously entered " + number);
                    //        continue;
                    //    }
                    //    numbers.Add(number);
                    //}
                    //numbers.Sort();

                    //foreach (var number in numbers)
                    //    Console.WriteLine(number);

                    break;
                case 4:
                    var numberList = new List<int>();
                    while (true)
                    {
                        Console.Write("Enter a number or type 'Quit' to exit: ");
                        var number= Console.ReadLine();
                        if (number.ToLower()=="quit")
                            break;
                        
                        numberList.Add(Int32.Parse(number));
                    }

                    for (int i=0;i<numberList.Count;i++)
                    {
                        int lastIndex = numberList.LastIndexOf(numberList[i]);
                        
                        if (i == lastIndex)
                            Console.WriteLine(numberList[i]);
                    }

                    // MOSH SOLUTION
                    //var numbers = new List<int>();

                    //while (true)
                    //{
                    //    Console.Write("Enter a number (or 'Quit' to exit): ");
                    //    var input = Console.ReadLine();

                    //    if (input.ToLower() == "quit")
                    //        break;

                    //    numbers.Add(Convert.ToInt32(input));
                    //}

                    //var uniques = new List<int>();
                    //foreach (var number in numbers)
                    //{
                    //    if (!uniques.Contains(number))
                    //        uniques.Add(number);
                    //}

                    //Console.WriteLine("Unique numbers:");
                    //foreach (var number in uniques)
                    //    Console.WriteLine(number);

                    break;
                case 5:
                    Console.WriteLine("Enter a list of comma separated numbers (e.g 5, 1, 9, 2, 10):");
                    string[] strNumbers;
                    while (true)
                    {
                        string strNumberComma = Console.ReadLine();
                        if (String.IsNullOrWhiteSpace(strNumberComma))
                        {
                            Console.WriteLine("Empty list. Please re-try");
                            continue;
                        }
                        strNumbers = strNumberComma.Split((','));
                        if (strNumbers.Length<5)
                        {
                            Console.WriteLine("ınvalid List. Please re-try");
                            continue;
                        }
                        break;
                    }
                    var intNumbers = new int[strNumbers.Length];
                    for (int i = 0; i < strNumbers.Length; i++)
                    {
                        intNumbers[i] = Int32.Parse(strNumbers[i]);
                    }
                    Array.Sort(intNumbers);

                    Console.WriteLine("Number1: {0}\nNumber2: {1}\nNumber3: {2}", intNumbers[0], intNumbers[1], intNumbers[2]);
                    break;
                default:
                    Console.WriteLine("Bu Exercises mevcut değil");
                    break;
            }
                    
            
        }

        public static void Run4(int exerciseNo)
        {
            switch (exerciseNo)
            {
                case 1:
                    Console.WriteLine("Enter a few numbers separated by a hyphen (eg 1-2-3-4):");
                    var numbers = Console.ReadLine().Split('-');

                    var isConsecutive = true;
                    for (int i = 1; i < numbers.Length; i++)
                    {
                        int abs = System.Math.Abs(Int32.Parse(numbers[i-1]) - Int32.Parse(numbers[i]));

                        if (abs != 1)
                        {
                            isConsecutive = false;
                            break;
                        }
                    }

                    var message = isConsecutive ? "Consecutive" : "Not Consecutive";
                    Console.WriteLine(message);
                    break;
                case 2:
                    Console.WriteLine("Enter a few numbers separated by a hyphen:");
                    var input = Console.ReadLine();
                    
                    if (String.IsNullOrEmpty(input))
                        break;

                    var numbers2 = input.Split('-');
                    Array.Sort(numbers2);
                    for (int i = 1; i < numbers2.Length; i++)
                    {
                        if (numbers2[i-1]==numbers2[i])
                        {
                            Console.WriteLine("Duplicate");
                            break;
                        }
                           
                    }

                    // MOSH SOLUTION
                    Console.Write("Enter a few numbers (eg 1-2-3-4): ");
                    //var input = Console.ReadLine();

                    //if (String.IsNullOrWhiteSpace(input))
                    //    return;

                    //var numbers = new List<int>();
                    //foreach (var number in input.Split('-'))
                    //    numbers.Add(Convert.ToInt32(number));

                    //var uniques = new List<int>();
                    //var includesDuplicates = false;
                    //foreach (var number in numbers)
                    //{
                    //    if (!uniques.Contains(number))
                    //        uniques.Add(number);
                    //    else
                    //    {
                    //        includesDuplicates = true;
                    //        break;
                    //    }
                    //}

                    //if (includesDuplicates)
                    //    Console.WriteLine("Duplicate");

                    break;
                case 3:
                    Console.WriteLine("Enter a time value in 24-hour time format:");
                    var input3 = Console.ReadLine();

                    var components = input3.Split(':');
                    if (components.Length!=2)
                    {
                        Console.WriteLine("Invalid Time");
                        break;
                    }

                    var timeSpan = new TimeSpan();
                    if (TimeSpan.TryParse(input3, out timeSpan))
                    {
                        Console.WriteLine("OK. Time is: {0}:{1}",timeSpan.Hours,timeSpan.Minutes);
                        break;
                    }

                    Console.WriteLine("Invalid Time");
                    
                    break;
                case 4:
                    Console.WriteLine("Enter a few words separated by a space:");
                    var input4 = Console.ReadLine();
                    var words = input4.Split(" ");

                    for (int i=0;i<words.Length;i++)
                    {
                        var builder = new StringBuilder(words[i]);
                        for (int j = 0; j < builder.Length; j++)
                        {
                            if (j == 0)
                            {
                                builder.Replace(builder[j], Char.ToUpper(builder[j])).ToString();
                            }
                            else
                            {
                                builder.Replace(builder[j], Char.ToLower(builder[j])).ToString();
                            }
                        }
                        words[i] = builder.ToString();
                    }
                    Console.WriteLine(String.Join("", words));

                    // MOSH SOLUTION
                    //var variableName = "";
                    //foreach (var word in input4.Split(' '))
                    //{
                    //    var wordWithPascalCase = char.ToUpper(word[0]) + word.ToLower().Substring(1);
                    //    variableName += wordWithPascalCase;
                    //}

                    //Console.WriteLine(variableName);

                    break;
                case 5:
                    Console.WriteLine("Enter an English word:");
                    var input5 = Console.ReadLine().ToLower();
                    var builder5 = new StringBuilder(input5);
                    var output= builder5.Replace('a', ' ')
                        .Replace('e', ' ')
                        .Replace('i', ' ')
                        .Replace('o', ' ')
                        .Replace('u', ' ')
                        .ToString();

                    Console.WriteLine(output.Split(' ').Length - 1);

                    // MOSH SOLUTION
                    //Console.Write("Enter a word: ");
                    // Note the ToLower() here. This is used to count for both A and a. 
                    //var input = Console.ReadLine().ToLower();

                    //var vowels = new List<char>(new char[] { 'a', 'e', 'o', 'u', 'i' });
                    //var vowelsCount = 0;
                    //foreach (var character in input)
                    //{
                    //    if (vowels.Contains(character))
                    //        vowelsCount++;
                    //}

                    //Console.WriteLine(vowelsCount);

                    break;
                default:
                    Console.WriteLine("Bu Exercises mevcut değil");
                    break;

            }
            
            
        }

        public static void Run5()
        {
            var pathReadingFile = @"C:\Users\Admin\OneDrive - pitools\Masaüstü\Folder\destination\somefile_copy.txt";

            var text = File.ReadAllText(pathReadingFile);
            Console.WriteLine("Text in the file: " + text);

            var words = text.Split(' ');
            Console.WriteLine("The number of words in the file: " + words.Length);

            var longestWord = words[0];
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > longestWord.Length)
                {
                    longestWord = words[i];
                }
            }
            Console.WriteLine("The longest word in the file is: " + longestWord);
        }

    }
}