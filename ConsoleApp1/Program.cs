using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
using System.Xml.Schema;
using CSharpFundamentals.Math;
using Microsoft.VisualBasic;
using Console = System.Console;


namespace CSharpFundamentals
{
    class Program
    {
        public static void Increment(int number)
        {
            number += 10;
        }

        public static void MakeOld(Person person)
        {
            person.Age += 10;
        }

        static void Main(string[] args)
        {

           








            if (false)
            {
                Console.Write("write Run Number and ENTER: ");
                var runNumber = Console.ReadLine();
                Console.Write("Write Exercise No and ENTER: ");
                var exerciseNo = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(runNumber) && !String.IsNullOrWhiteSpace(exerciseNo))
                    RunExercises.RunMain(Int32.Parse(runNumber), Int32.Parse(exerciseNo));
                else
                    Console.WriteLine("ENTER or null inputs are not acceptable...");

            }

            



            


            






        }

    }
}
