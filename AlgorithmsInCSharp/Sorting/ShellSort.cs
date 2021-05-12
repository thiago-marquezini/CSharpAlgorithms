using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgorithmsInCSharp.Sorting
{
    /*
     * This algorithm was created by Donald Shell and it is a improvement of the Insertion Sort algorithm. 
     * The concept of this algorithm is to compare elements that are distant from each other, instead of comparing adjacent elements as it is done by the Insertion Sort algorithm. The distance of the elements decrease as the algorithm loops through the array.
     */
    public class ShellSort
    {
        public static bool SortSample()
        {
            Random rand = new Random();
            int[] arr = Enumerable.Repeat(0, 10).Select(i => rand.Next(0, 20)).ToArray();

            Console.WriteLine($"Initial Array: {string.Join(", ", arr)}");

            int trackPosition;
            int temp;
            int h = 1;

            while (h <= arr.Length)
            {
                h = h * 3 + 1;
            }

            while (h > 0)
            {
                for(int i = h; i <= arr.Length - 1; i++)
                {
                    temp = arr[i];
                    trackPosition = i;

                    //This variable is used only for the print of the steps of the algorithm
                    List<int> positionsToMarkOutoput = new List<int>() { trackPosition, i };

                    while (trackPosition > h - 1 && arr[trackPosition-h] >= temp)
                    {                     
                        arr[trackPosition] = arr[trackPosition - h];
                        trackPosition -= h;

                        //This line is used only for the print of the steps of the algorithm
                        positionsToMarkOutoput.Add(trackPosition);
                    }
                    arr[trackPosition] = temp;

                    Console.WriteLine($@"Step: {string.Join(", ", arr.Select((a, index) => positionsToMarkOutoput.Contains(index) ? $"<{a}>" : a.ToString()))}");
                }
                h = (h - 1) / 3;
            }

            Console.WriteLine($"Array sorted: {string.Join(", ", arr)}");

            return true;
        }
    }
}
