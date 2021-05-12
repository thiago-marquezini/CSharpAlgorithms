using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgorithmsInCSharp.Bucket.Sorting
{
    /*
     * 
     * The Bucket Sort algorithm split an array into buckets, then the elements into these buckets are sorted individually using a different sorting algorithm (Insertion Sort was used for this example). In the end the sorted elements are retrieved from the buckets in order to compilate a resulting sorted array.
     * 
     */
    public class BucketSortSample
    {
        public static bool SortSample()
        {
            Random rand = new Random();
            int[] arr = Enumerable.Repeat(0, 10).Select(i => rand.Next(0, 99)).ToArray();

            Console.WriteLine($"Initial Array: {string.Join(", ", arr)}");

            int[] result = BucketSort(arr);

            Console.WriteLine($"Array sorted: {string.Join(", ", result)}");

            return true;
        }

        static int[] BucketSort(int[] arr)
        {
            int[] result = new int[arr.Length];

            int numBuckets = 10;

            List<int>[] buckets = new List<int>[numBuckets];
            for(int i = 0; i < numBuckets; i++)
            {
                buckets[i] = new List<int>();
            }

            for (int i = 0; i < arr.Length; i++)
            {
                buckets[ arr[i] / numBuckets ].Add(arr[i]);
            }
            Console.WriteLine(string.Join(Environment.NewLine, buckets.Select((b, index) => "Bucket " + index + ": " + string.Join(", ", b))));

            Console.WriteLine("Sorting the elements of each bucket and extracting the sorted elements from the buckets.");
            int resultPosition = 0;
            for (int i = 0; i < numBuckets; i++)
            {
                if (buckets[i].Count() == 0)
                    continue;
                
                int[] auxiliar = InsertionSort(buckets[i].ToArray());
                Console.WriteLine($"Bucket {i} sorted: {string.Join(", ", auxiliar)}");
                for (int j = 0; j < auxiliar.Length; j++)
                {
                    result[resultPosition++] = auxiliar[j];
                }
            }

            return result;
        }

        //Refer to Insertion Sort algorithm
        static int[] InsertionSort(int[] arr)
        {
            int trackPosition;
            int currentElement;
            for (int i = 1; i < arr.Length; i++)
            {
                currentElement = arr[i];
                trackPosition = i;

                while (trackPosition > 0 && arr[trackPosition - 1] >= currentElement)
                {
                    arr[trackPosition] = arr[trackPosition - 1];
                    trackPosition--;
                }

                arr[trackPosition] = currentElement;
            }

            return arr;
        }
    }
}
