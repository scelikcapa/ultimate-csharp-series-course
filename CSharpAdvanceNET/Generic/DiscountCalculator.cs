using System.CodeDom;

namespace CSharpAdvanceNET.Generic
{
    // 5 Types of Constraints
    // where T : IComparable
    // where T : Product
    // where T : struct
    // where T : class
    // where T : new()

    public class DiscountCalculator<TProduct> where TProduct : Product
    {
        public float CalculateDiscount(TProduct product)
        {
            return product.Price;
        }

    }
}