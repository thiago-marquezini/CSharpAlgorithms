using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsInCSharp.Sorting
{
    /*
     * The Quicksort is a efficient sorting algorithm that uses the divide-and-concquer stratey. It works by selecting an element from the array, which is called "pivot", and than the algorithm divides and reorganizes the array recursively in a way that the elements from the left of the pivot are less than the pivot and the elements from the right are greater than the pivot.
     * 
     */
    public class QuickSortSample
    {
        public static bool SortSample()
        {
            Random rand = new Random();
            int[] arr = Enumerable.Repeat(0, 10).Select(i => rand.Next(0, 40)).ToArray();

            Console.WriteLine($"Initial Array: {string.Join(", ", arr)}");

            QuickSort(arr, 0, arr.Length-1);

            Console.WriteLine($"Array sorted: {string.Join(", ", arr)}");

            return true;
        }

        static void QuickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int partPosition = Partition(arr, start, end);

                QuickSort(arr, start, partPosition - 1);
                QuickSort(arr, partPosition + 1, end);
            }
        }

        static int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[end];
            int indexStart = start - 1;

            Console.WriteLine(System.Environment.NewLine + $@"Pivot: {pivot} - Index position: {end}");
            Console.WriteLine($@"Start: {start} - End: {end}");
            Console.WriteLine($@"Array: {string.Join(", ", arr)}");

            for (int i = start; i < end; i++)
            {
                if (arr[i] < pivot)
                {
                    indexStart++;
                    Swap(arr, indexStart, i);
                }
            }
            Swap(arr, indexStart + 1, end);

            return indexStart + 1;
        }

        static void Swap(int[] arr, int arrPos1, int arrPos2)
        {
            int temp = arr[arrPos1];
            arr[arrPos1] = arr[arrPos2];
            arr[arrPos2] = temp;

            Console.WriteLine($@"Step: {string.Join(", ", arr.Select((a, index) => index == arrPos1 || index == arrPos2 ? $"<{a}>" : a.ToString()))}");
        }
    }
}
