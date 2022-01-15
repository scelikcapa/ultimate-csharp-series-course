using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CSharpAdvanceNET.Delegates;
using CSharpAdvanceNET.Generic;
using Microsoft.SqlServer.Server;

namespace CSharpAdvanceNET
{
    class Program
    {
        static void Main(string[] args)
        {
            // extra Square method needed without lambda expressions
            // Console.WriteLine(Square(5));

            // with lambda expressions, dont have to extra method
            // have to use delegates to work with lambda expressions
            // args => expression
            // number => number*number;


            // Func<int, int> square = Square;
            Func<int, int> square = number => number * number;
            Console.WriteLine(square(5));


            // VIDEO 5:00 
        }
            

        //static int Square(int number)
        //{
        //    return number * number;
        //}
        
    }
}
