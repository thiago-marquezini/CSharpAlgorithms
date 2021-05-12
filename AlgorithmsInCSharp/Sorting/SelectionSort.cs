using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgorithmsInCSharp.Sorting
{
    /*
     * This sorting algorithm compares the first element of the array with the other elements, then it places the smallest element in the first position of the array and moves to the next position, starting again the process comparing the next element to the rest of the array until the end of the array.
     * This algorithm has two loops, the outer loop tracks each element of the array from the first position and the inner loop is used to compare each element of the array with the first positions being tracked by the outer loop, in sequence, and registering in each step the position of the smallest element to be placed in the position tracked by the outer loop.
     */
    public class SelectionSort
    {
        public static bool SortSample()
        {
            Random rand = new Random();
            int[] arr = Enumerable.Repeat(0, 10).Select(i => rand.Next(0, 20)).ToArray();

            Console.WriteLine($"Initial Array: {string.Join(", ", arr)}");

            int min;
            int temp;
            for (int start = 0; start < arr.Length; start++)
            {
                min = start;
                for(int next = start + 1; next < arr.Length; next++)
                {
                    if (arr[next] < arr[min])
                    {
                        min = next;
                    }
                }
                temp = arr[start];
                arr[start] = arr[min];
                arr[min] = temp;

                Console.WriteLine($@"Step: {string.Join(", ", arr.Select((a,i) => i == start || i == min? $"<{a}>" : a.ToString()))}");
            }

            Console.WriteLine($"Array sorted: {string.Join(", ", arr)}");

            return true;

        }
    }
}
