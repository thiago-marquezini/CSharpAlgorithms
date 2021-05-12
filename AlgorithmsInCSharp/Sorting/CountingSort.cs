using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgorithmsInCSharp.Sorting
{
    /*
     * The Counting Sort algorithm uses a counter array to register the number of ocurrences of each element in the main array to be ordered. After storing the number of ocurrences, it sums each position of the counter with the previous position. The resulting counter array is used as an index to map each element of the main array to the corresponding ordered position.
     * 
     */
    public class CountingSort
    {
        public static bool SortSample()
        {
            Random rand = new Random();
            int[] arr = Enumerable.Repeat(0, 10).Select(i => rand.Next(0, 20)).ToArray();

            Console.WriteLine($"Initial Array: {string.Join(", ", arr)}");

            var resultArray = CountSort(arr);                

            Console.WriteLine($"Array sorted: {string.Join(", ", resultArray)}");

            return true;
        }

        static int[] CountSort(int[] arr)
        {
            int[] result = new int[arr.Length];
            int max = arr[0];

            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            Console.WriteLine($@"Maximum element: {Environment.NewLine + max}");

            int[] count = new int[max + 1];

            for(int i = 0; i < arr.Length; i++)
            {
                count[arr[i]]++;
            }
            Console.WriteLine($@"Counter array to register the number of times the elements occurs in the main array: {Environment.NewLine + string.Join(", ", count)}");

            for (int i = 1; i <= max; i++)
            {
                count[i] += count[i - 1];
            }
            Console.WriteLine($@"Counter array with prior element summed: {Environment.NewLine +  string.Join(", ", count)}");

            //This step calculates and insert the elements in the corresponding ordered position
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                result[count[arr[i]] - 1] = arr[i];
                count[arr[i]]--;
            }

            return result;
        }
    }
}
