using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Amazon
{
    public class CustomerAccess
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Promote()
        {
            var ratingPrivate =CalculateRatingPrivate(excludeOrders:true);

            var ratingProtected = CalculateRatingProtected();
            
            var calculator = new RateCalculator();
            var ratingInternal = calculator.Calculate(this);

            Console.WriteLine("Promote from Amazon Class Library (DLL)");


        }

        // CANNOT be seen from derived class
        private int CalculateRatingPrivate(bool excludeOrders)
        {
            return 0;
        }

        // CAN be seen from derived class.
        // try to avoid protected unless you have a valid reason to use
        // bad result, encapsulation is broken
        protected int CalculateRatingProtected()
        {
            return 0;
        }
    }
}
