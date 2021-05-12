using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgorithmsInCSharp.Sorting
{
    /*
     * This sorting algorithm is compared to how cards are organized in a game cards. It's like having a hand of cards in your hands, and in each step when you receive a new card, you insert this new card in your hand so all the cards stay  organized in a sorted way. 
     * This sorting algorithm shifts the greater elements of the array to the positions in the right in each step of the outer loop, tracking each element from the array from the left to the right and searching it's correct place shifting the previous elements of the array if they are greater than the current element tracked by the outer loop. It's like moving a bunch of cards in your hands to find the correct place for a new card to keep all organized in a sorted way.
     */
    public class InsertionSort
    {
        public static bool SortSample()
        {
            Random rand = new Random();
            int[] arr = Enumerable.Repeat(0, 10).Select(i => rand.Next(0, 20)).ToArray();

            Console.WriteLine($"Initial Array: {string.Join(", ", arr)}");

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

                Console.WriteLine($@"Step: {string.Join(", ", arr.Select((a, index) => index == i || index == trackPosition ? $"<{a}>" : a.ToString()))}");

            }

            Console.WriteLine($"Array sorted: {string.Join(", ", arr)}");

            return true;
        }
    }
}
