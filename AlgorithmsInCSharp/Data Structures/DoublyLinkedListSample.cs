using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmsInCSharp.Data_Structures.DoublyLinkedList
{
    /*
     * A doubly linked list is a data structure composed by a collection of nodes, in which each node points to the next and the next node points to the previous, consisting in a sequence of linked elements which can be traversed in forward and backward direction.
     */
    public class DoublyLinkedListSample
    {
        public static bool Sample()
        {
            DoublyLinkedList list = new DoublyLinkedList();

            //List final sequence: 7 1 2 3 6 4 5 8 9 10

            list.AddNodeHead(1);
            list.AddNodeTail(2);
            Node node3 = list.AddNodeTail(3);
            list.AddNodeTail(4);
            Node node5 = list.AddNodeTail(5);
            //7 becomes Head of the list
            Node node7 = list.AddNodeHead(7);
            list.AddNodeTail(8);
            list.AddNodeTail(9);
            list.AddNodeTail(10);
            //Insert 6 between 3 and 4
            list.InsertNode(node3, 6);

            Console.WriteLine("Doubly linked list content display");
            Console.WriteLine("Print from node 7 (Head)");
            list.Display(node7);

            Console.WriteLine(Environment.NewLine + "Print from node 5");
            list.Display(node5);

            return true;
        }
    }

    public class Node
    {
        public int Data { get; set;  }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
            Prev = null;
        }
    }

    public class DoublyLinkedList
    {
        private Node Head;
        
        public Node AddNodeHead(int data)
        {
            Node newNode = new Node(data);

            newNode.Next = Head;
            newNode.Prev = null;

            if (Head != null)
            {
                Head.Prev = newNode;
            }

            Head = newNode;

            return newNode;
        }

        public Node InsertNode(Node prevNode, int data)
        {
            if (prevNode == null)
            {
                AddNodeHead(data);
            }

            Node newNode = new Node(data);

            newNode.Next = prevNode.Next;
            prevNode.Next = newNode;
            newNode.Prev = prevNode;

            if (newNode.Next != null)
            {
                newNode.Next.Prev = newNode;
            }

            return newNode;
        }

        public Node AddNodeTail(int data)
        {
            Node newNode = new Node(data);

            newNode.Next = null;

            if (Head == null)
            {
                newNode.Prev = null;
                Head = newNode;
                return newNode;
            }

            Node last = Head;

            while (last.Next != null)
            {
                last = last.Next;
            }

            last.Next = newNode;
            newNode.Prev = last;

            return newNode;
        }

        public void Display(Node node)
        {
            Node nodeAux = node;

            Console.WriteLine("Traverse in forward direction:");
            while (node != null)
            {
                Console.Write(node.Data + " ");
                node = node.Next;
            }

            Console.WriteLine(Environment.NewLine + "Traverse in backward direction:");
            while (nodeAux != null)
            {
                Console.Write(nodeAux.Data + " ");
                nodeAux = nodeAux.Prev;
            }
        }
    }


    


}
