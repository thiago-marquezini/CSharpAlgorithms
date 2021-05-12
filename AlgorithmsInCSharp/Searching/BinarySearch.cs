using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgorithmsInCSharp.Searching
{
    /*
     * When the array being searched is already sorted into order, the Binary Search algorithm can be used to search for a specific element  . This algorithm consists in choosing the middle element of the array, comparing it to the element being searched and reducing the array to the half in each step, for the range where the element probably is located, if the middle element is not equal to the element being searched. Then the middle element is taken from the new range, repeating the process until the element being searched is located.
     * This algorithm consists in reducing the array search range in half until it finds the elemnt being seached, comparing the middle elements to the element being searched. The search range of the array is reduced to the upper half or lower half depending if the middle element is higher or lesser then the element being searched.
     */
    public class BinarySearchSample
    {
        public static bool SearchSample()
        {
            Random rand = new Random();
            int[] arr = Enumerable.Repeat(0, 40).Select(i => rand.Next(0, 100)).OrderBy(i => i).ToArray();
            int elementToSearch = rand.Next(0, 100);

            Console.WriteLine($"Initial Array: {string.Join(", ", arr)}");
            Console.WriteLine($"Element to be searched in the array: {elementToSearch}");

            int positionFound = BinarySearch(arr, elementToSearch);
            //or
            //int positionFound = RecursiveBinarySearch(arr, elementToSearch, 0, arr.Length - 1);

            if (positionFound == -1)
            {
                Console.WriteLine("Element was not found in the array");
            }
            else
            {
                Console.WriteLine($"Element was found at position {positionFound} in the array");
            }

            return true;
        }

        public static int BinarySearch(int[] arr, int elementToSearch)
        {
            int start = 0;
            int end = arr.Length - 1;
            int middle;
            while (start <= end)
            {
                middle = (end + start) / 2;

                Console.WriteLine(
                    $@"Step:{string.Join(", ", 
                        arr.Skip(start).Take(end - start + 1)
                           .Select((a, i) => i + start == middle ? $"<{a}>" : a.ToString()))
                    }");

                
                if (arr[middle] == elementToSearch)
                {
                    return middle;
                }
                else if (elementToSearch < arr[middle])
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
                
            }
            return -1;
        }

        public static int RecursiveBinarySearch(int[] arr, int elementToSearch, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }
            else
            {
                int middle = (end + start) / 2;

                Console.WriteLine(
                    $@"Step:{string.Join(", ",
                        arr.Skip(start).Take(end - start + 1)
                           .Select((a,i) => i + start == middle ? $"<{a}>" : a.ToString()))
                    }");

                if (arr[middle] == elementToSearch)
                {
                    return middle;
                }
                else if (elementToSearch < arr[middle])
                {
                    return RecursiveBinarySearch(arr, elementToSearch, start, middle - 1);
                }
                else
                {
                    return RecursiveBinarySearch(arr, elementToSearch, middle + 1, end);
                }
            }
        }
    }
}
