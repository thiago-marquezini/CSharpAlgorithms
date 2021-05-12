using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgorithmsInCSharp.Sorting
{
    /*
     * This sorting algorithm receives this name because the values float like a bubble from one end of the array to another
     * This algorithm is composed by two loops. The outer loop tracks the arrays from last element to the first. The inner loop is 
     * used to track the same array from the start until the element postion tracked by the outer loop, which beggins in the last position. For each step in the inner loop, each element from the start position is compared to the next element. If the start element is greater than the next one, then the positions are exchanged in pairs. This process is repeated until it reaches the end of the array, then the outer loop reduces the range to be tracked and ordered for the next steps, considering that each step will place the greater value at the end of the array.
     */
    public class BubbleSort
    {
        public static bool SortSample()
        {
            Random rand = new Random();
            int[] arr = Enumerable.Repeat(0, 10).Select(i => rand.Next(0, 20)).ToArray();

            Console.WriteLine($"Initial Array: {string.Join(", ", arr)}");

            int temp;
            for (int end = arr.Length-1; end >= 1; end--)
            {
                for(int start = 0; start <= end-1; start++)
                {
                    if (arr[start] > arr[start + 1])
                    {
                        temp = arr[start];
                        arr[start] = arr[start+1];
                        arr[start + 1] = temp;
                        
                        Console.WriteLine($@"Step: {string.Join(", ", arr.Select((a,i) => i == start + 1 ? $"<{a}>" : a.ToString()))}");
                    }
                }
            }

            Console.WriteLine($"Array sorted: {string.Join(", ", arr)}");

            return true;
        }
    }
}
