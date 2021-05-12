using System;
using System.Linq;
using AlgorithmsInCSharp.Arrays;
using AlgorithmsInCSharp.Searching;
using AlgorithmsInCSharp.Sorting;
using AlgorithmsInCSharp.Extensions;
using AlgorithmsInCSharp.Searching.DFS;
using AlgorithmsInCSharp.Sorting.Radix;
using AlgorithmsInCSharp.Bucket.Sorting;
using AlgorithmsInCSharp.Data_Structures;
using AlgorithmsInCSharp.Data_Structures.DoublyLinkedList;
using AlgorithmsInCSharp.Miscellaneous;

namespace AlgorithmsInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            bool optionChosen = true;
            
            while (optionChosen)
            {
                string option = Options.ChooseTopic();

                while (!int.TryParse(option, out _) || int.Parse(option) < 1 || int.Parse(option) > 26)
                {
                    Console.WriteLine("Invalid option.");

                    option = Console.ReadLine();
                }

                optionChosen = option switch
                {
                    "1" => SinglyLinkedListSample.Sample(),
                    "2" => DoublyLinkedListSample.Sample(),
                    "3" => ArraySamples.SingleDimensionalArrays(),
                    "4" => ArraySamples.MultidimensionalArrays(),
                    "5" => ArraySamples.JaggedArrays(),
                    "6" => ArraySamples.ArrayListClass(),
                    "7" => BubbleSort.SortSample(),
                    "8" => SelectionSort.SortSample(),
                    "9" => InsertionSort.SortSample(),
                    "10" => ShellSort.SortSample(),
                    "11" => MergeSort.SortSample(),
                    "12" => HeapSort.SortSample(),
                    "13" => QuickSortSample.SortSample(),
                    "14" => CountingSort.SortSample(),
                    "15" => RadixSortSample.SortSample(),
                    "16" => BucketSortSample.SortSample(),
                    "17" => SequentialSearch.SearchSample(),
                    "18" => BinarySearchSample.SearchSample(),
                    "19" => TestBinarySearchTree(),
                    "20" => BreadthFirstSearchSample.SearchSample(),
                    "21" => DepthFirstSearchSample.SearchSample(),
                    "22" => FibonacciSample.Run(),
                    "23" => AnagramSample.Run(),
                    "24" => PalindromeSample.Run(),
                    "25" => Euclidean.Run(),
                    _ => false,
                };

                Console.ReadKey();
            }
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("An error ocurred during execution:");
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }

        static bool TestBinarySearchTree()
        {
            int[] arr = { 10, 17, 15, 45, 7, 3, 9, 50, 52, 23 };

            Console.WriteLine($"Array values: {string.Join(", ", arr)}");

            BinarySearchTree bst = new BinarySearchTree();

            foreach (var data in arr)
            {
                bst.Insert(data);
            }

            Console.WriteLine("\nTree representation:");
            bst.RootNode.Print();

            Console.WriteLine("\nTraversing the tree in order: ");
            bst.Traversing(bst.RootNode);

            Console.WriteLine();

            Console.WriteLine("\nSearching for node 9: ");
            var node = bst.Find(9);
            Console.WriteLine($"Node {(node == null ? "not found" : "found")}");

            var minNode = bst.GetMinimum();
            Console.WriteLine($"\nMinimum node: {minNode.Data}");

            var maxNode = bst.GetMaximum();
            Console.WriteLine($"\nMaximum node: {maxNode.Data}");

            Console.WriteLine("\nRemoving node 3 (Node with no childs): ");
            bst.Delete(3);
            bst.RootNode.Print();

            Console.WriteLine("\nRemoving node 50 (Node with one child): ");
            bst.Delete(50);
            bst.RootNode.Print();

            Console.WriteLine("\nRemoving node 17 (Node with two childs): ");
            bst.Delete(17);
            bst.RootNode.Print();

            return true;
        }
    }
}
