using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpFundamentals
{
    class DebugExamples
    {
        public static List<int> GetSmallests(List<int> list, int count)
        {
            if (list == null)
                throw new ArgumentOutOfRangeException("list","List cannot be null");

            if (count > list.Count || count <= 0)
                throw new ArgumentOutOfRangeException("count",
                    "Count should be between 1 and the number of elements in the list");
            // SIDE EFFECTS - Old code deletes original list. So copy original list to buffer list and delete it
            var buffer = new List<int>(list);
            var smallests = new List<int>();


            while (smallests.Count < count)
            {
                var min = GetSmallest(buffer);
                smallests.Add(min);
                buffer.Remove(min);
            }

            return smallests;
        }

        public static int GetSmallest(List<int> list)
        {
            // Assume the first number is the smallest
            var min = list[0];
            for (var i = 1; i < list.Count; i++)
            {
                if (list[i] < min)
                    min = list[i];
            }
            return min;
        }
    }
}
