using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsInCSharp
{
    static class Options
    {
        public static string ChooseTopic()
        {
            Console.WriteLine("Choose a Topic to test:");
            Console.WriteLine("DATA STRUCTURES");
            Console.WriteLine("1 - Singly Linked List");
            Console.WriteLine("2 - Doubly Linked List");
            Console.WriteLine("ARRAY SAMPLES");
            Console.WriteLine("3 - Single Dimensional");
            Console.WriteLine("4 - Multidimensional");
            Console.WriteLine("5 - Jagger Arrays");
            Console.WriteLine("6 - Array List");
            Console.WriteLine("SORT ALGORITHMS");
            Console.WriteLine("7 - Bubble Sort");
            Console.WriteLine("8 - Selection Sort");
            Console.WriteLine("9 - Insertion Sort");
            Console.WriteLine("10 - Shell Sort");
            Console.WriteLine("11 - Merge Sort");
            Console.WriteLine("12 - Heap Sort");
            Console.WriteLine("13 - Quick Sort");
            Console.WriteLine("14 - Counting Sort");
            Console.WriteLine("15 - Radix Sort");
            Console.WriteLine("16 - Bucket Sort");
            Console.WriteLine("SEARCH ALGORITHMS");
            Console.WriteLine("17 - Sequential Search");
            Console.WriteLine("18 - Binary Search");
            Console.WriteLine("19 - Binary Search Tree");
            Console.WriteLine("20 - Breadth First Search ");
            Console.WriteLine("21 - Depth First Search");
            Console.WriteLine("MISCELANEOUS");
            Console.WriteLine("22 - Fibonacci");
            Console.WriteLine("23 - Anagram");
            Console.WriteLine("24 - Palindrome");
            Console.WriteLine("25 - Euclidean");
            Console.WriteLine("- EXIT -");
            Console.WriteLine("26");

            return Console.ReadLine();
        }

    }
}
