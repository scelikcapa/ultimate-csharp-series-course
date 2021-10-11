using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Channels;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            byte oneByte1=255;
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


            Console.WriteLine("{0} {1}",byte.MaxValue,byte.MinValue);


            //TYPE CONVERSION
            //Implicite

        }
    }
}
