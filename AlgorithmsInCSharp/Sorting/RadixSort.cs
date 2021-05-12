using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgorithmsInCSharp.Sorting.Radix
{
    /*
     * The Radix Sort algorithm uses a counter array (refer to Couting Sort algorithm) to store the number of ocurrences of each element in the main array grouping by digit places, beggining by the unit place and incresing to the next digits (tenth, hundredth...). After storing the number of ocurrences, it sums each position of the counter with the previous position, for each digit place. The resulting counter array is used as an index to map each element of the main array to the corresponding sorted position, for each digit place, eventually resulting in a sorted array.
     * 
     */
    public class RadixSortSample
    {
        public static bool SortSample()
        {
            Random rand = new Random();
            int[] arr = Enumerable.Repeat(0, 10).Select(i => rand.Next(0, 200)).ToArray();

            Console.WriteLine($"Initial Array: {string.Join(", ", arr)}");

            RadixSort(arr);                

            Console.WriteLine($"Array sorted: {string.Join(", ", arr)}");

            return true;
        }

        static void RadixSort(int[] arr)
        {
            int max = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            Console.WriteLine($@"Maximum element: {Environment.NewLine + max}");

            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountSort(arr, exp);
            }
                
        }


        //Refer to the Couting Sort algorithm
        static void CountSort(int[] arr, int exp)
        {
            int[] result = new int[arr.Length];
            int[] count = new int[10];

            for(int i = 0; i < arr.Length; i++)
            {
                count[ (arr[i] / exp) % 10 ]++;
            }
            string digitPosition = exp.ToString().Length == 1 ? "unit" : exp.ToString().Length == 2 ? "tenth" : "hundredth";
            Console.WriteLine($@"Counter array to store the number of times the elements in the {digitPosition} place occurs in the main array: {Environment.NewLine + string.Join(", ", count)}");

            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }
            Console.WriteLine($@"Counter array with prior element summed: {Environment.NewLine +  string.Join(", ", count)}");

            //This step calculates and insert the elements in the corresponding ordered position, according to current digit
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                result[count[ (arr[i] / exp) % 10 ] - 1] = arr[i];
                count[ (arr[i] / exp) % 10 ]--;
            }

            //Updating the main array with the sorted numbers for the current digit
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = result[i];
            }
            Console.WriteLine($@"Sorted array considering the {digitPosition} place: {Environment.NewLine + string.Join(", ", arr)}");
        }
    }
}
