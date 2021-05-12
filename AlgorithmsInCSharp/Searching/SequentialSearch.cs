using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgorithmsInCSharp.Searching
{
    /*
     * This is the most simple type of search algorithm and it uses the most obvious logic to search an element inside an array, that consists in searching for an element sequenatially, beginning at the start of the array and moving through each record until the element is found.
     */
    public class SequentialSearch
    {
        public static bool SearchSample()
        {
            Random rand = new Random();
            int[] arr = Enumerable.Repeat(0, 10).Select(i => rand.Next(0, 20)).ToArray();
            int elementToSearch = rand.Next(0, 40);

            Console.WriteLine($"Initial Array: {string.Join(", ", arr)}");
            Console.WriteLine($"Element to be searched in the array: {elementToSearch}");

            bool found = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == elementToSearch)
                {
                    found = true;
                    break;
                }
            }

            Console.WriteLine($"Element was {(found ? "found" : "not found")} in the array");

            return true;
        }
    }
}
