using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsInCSharp.Sorting
{
    /*
     * Heapsort is a comparison based sorting algorithm which makes use of a data structure called Binary Heap. The Binary Heaps similar to a Binary Tree,  but it is usually build using arrays, intead of Node references.
     * This algorithm divides the array into a sorted and unsorted segments, and iteratively shrinks the unsorted region by extracting the largest element from it and inserting the element into the sorted region. 
     */
    public class HeapSort
    {
        public static bool SortSample()
        {
            Random rand = new Random();
            int[] arr = Enumerable.Repeat(0, 5).Select(i => rand.Next(0, 20)).ToArray();

            Console.WriteLine($"Initial Array: {string.Join(", ", arr)}");

            int size = arr.Length;
            int index = size / 2;
            int parent;
            int child;
            int t;

            while (true)
            {
                if (index > 0)
                {
                    index--; 
                    t = arr[index];
                }
                else
                {
                    size--;
                    if (size <= 0) 
                    { 
                        break; 
                    }
                    t = arr[size];
                    arr[size] = arr[0];

                    Console.WriteLine($@"Step: {string.Join(", ", arr.Select((a, index) => index == size || index == 0 ? $"<{a}>" : a.ToString()))}");
                }
                parent = index;
                child = ((index * 2) + 1);
                while (child < size)
                {
                    if ((child + 1 < size) && (arr[child + 1] > arr[child])) 
                    { 
                        child++; 
                    }

                    Console.WriteLine($@"Step: {string.Join(", ", arr.Select((a, index) => index == parent || index == child ? $"<{a}>" : a.ToString()))}");

                    if (arr[child] > t)
                    {
                        arr[parent] = arr[child];

                        Console.WriteLine($@"Step: {string.Join(", ", arr.Select((a, index) => index == parent || index == child ? $"<{a}>" : a.ToString()))}");

                        parent = child;
                        child = parent * 2 + 1;
                    }
                    else 
                    { 
                        break; 
                    }
                }
                arr[parent] = t;

                Console.WriteLine($@"Step: {string.Join(", ", arr.Select((a, index) => index == parent ? $"<{a}>" : a.ToString()))}");
            }

            Console.WriteLine($"Array sorted: {string.Join(", ", arr)}");

            return true;
        }
    }
}
