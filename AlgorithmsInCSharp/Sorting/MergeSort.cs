using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgorithmsInCSharp.Sorting
{
    /*
     * The MergeSort algorithm breaks the data set into two halves, until there is not more than two elements to be split and sort the halves recursively merging the segments in a ordered way.
     * The MergeSort algorithm breaks the data set into two halves, until there is not more than two elements to be split and sort the halves recursively merging the segments in a ordered way.
     */
    public class MergeSort
    {
        public static bool SortSample()
        {
            Random rand = new Random();
            int[] arr = Enumerable.Repeat(0, 10).Select(i => rand.Next(0, 20)).ToArray();

            Console.WriteLine($"Initial Array: {string.Join(" ", arr)}");

            RecursiveMergeSort(arr, 0, arr.Length - 1);

            Console.WriteLine($"Sorted Array: {string.Join(" ", arr)}");

            return true;
        }

        static void RecursiveMergeSort(int[] arr, int leftIndex, int rightIndex)
        {
            if (leftIndex == rightIndex)
            {
                return;
            }
            
            int middle = (int)((leftIndex + rightIndex) / 2);

            Console.WriteLine($"Dividing: {string.Join(" ", arr.Skip(leftIndex).Take(rightIndex - leftIndex + 1))}");
            RecursiveMergeSort(arr, leftIndex, middle);
            RecursiveMergeSort(arr, middle + 1, rightIndex);

            Merge(arr, leftIndex, middle, rightIndex);
        }

        static void Merge(int[] arr, int leftIndex, int middle, int rightIndex)
        {
            int[] tempArray = new int[arr.Length];
            for(int i = leftIndex; i <= rightIndex; i++)
            {
                tempArray[i] = arr[i];
            }

            Console.WriteLine($"Merging: {string.Join(" ", arr.Skip(leftIndex).Take(rightIndex - leftIndex + 1).Select((x,i) => (i == middle-leftIndex+1 ? $" | {x}" : x.ToString())))}");

            int positionSegment1 = leftIndex;
            int positionSegment2 = middle + 1;
            int index = leftIndex;

            while(positionSegment1 <= middle && positionSegment2 <= rightIndex)
            {
                if (tempArray[positionSegment1] < tempArray[positionSegment2])
                {
                    arr[index] = tempArray[positionSegment1];
                    positionSegment1++;
                }
                else
                {
                    arr[index] = tempArray[positionSegment2];
                    positionSegment2++;
                }
                index++;
            }

            while (positionSegment1 <= middle)
            {
                arr[index] = tempArray[positionSegment1];
                positionSegment1++;
                index++;
            }

            while(positionSegment2 <= rightIndex)
            {
                arr[index] = tempArray[positionSegment2];
                positionSegment2++;
                index++;
            }

            Console.WriteLine($"Merged: {string.Join(" ", arr.Skip(leftIndex).Take(rightIndex - leftIndex + 1))}");
        }
    }
}
