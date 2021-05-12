using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsInCSharp.Data_Structures
{
    /*
     * A singly linked list is a linear data structure composed by a collection of nodes, in which each node points to the next, consisting in a sequence of linked elements.
     */
    public class SinglyLinkedListSample
    {
        public static bool Sample()
        {
            Random rand = new Random();
            int[] arr = Enumerable.Repeat(0, 10).Select(i => rand.Next(0, 99)).ToArray();

            Console.WriteLine($"Initial Array: {Environment.NewLine + string.Join(", ", arr)}");

            SinglyLinkedList list = new SinglyLinkedList();

            for(int i = 0; i < arr.Length; i++)
            {
                list.AddNode(arr[i]);
            }

            Console.WriteLine("Singly linked list content display:");
            list.Display();

            return true;
        }
    }

    public class Node
    {
        public int Data { get; set;  }
        public Node Next { get; set; }
        public int Level { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    public class SinglyLinkedList
    {
        private Node Head;
        private Node Tail;
        
        public void AddNode(int data)
        {
            Node newNode = new Node(data);

            if (Head == null)
            {
                newNode.Level = 1;
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Level = Tail.Level + 1;
                Tail.Next = newNode;
                Tail = newNode;
            }
        }

        public void Display()
        {
            if (Head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            Node current = Head;
            while (current != null)
            {
                Console.WriteLine(new String(' ', current.Level) + (current == Head ? "Head" : "Next") + $" - level {current.Level}: {current.Data} ");
                current = current.Next;
            }
        }
    }


    


}
