using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgorithmsInCSharp.Searching
{
    /*
     * A Binary Tree is a tree composed by various nodes where each node can have up to two children nodes. Each parent node can have a left node and a right node, which can be used to store values in a ordered way. 
     * The following example uses integer values to demonstrate how these values can be stored in a tree, how to traverse all the values, how to implement methods to find a node, find teh minimum and maximum values, and also how to remove nodes from the tree.
     * The Node class represent each node of the tree, containing a integer value and the left and right nodes to store other values. The left node will store a value that is less then the current value of the parent node, and the right node will store value that is higher than the current value of the parent node.
     */

    public class Node
    {
        public int Data;
        public Node LeftNode;
        public Node RightNode;
    }

    public class BinarySearchTree
    {
        public Node RootNode;

        public void Insert(int data)
        {
            Node node = new Node() { Data = data };
            if (RootNode == null)
            {
                RootNode = node;
            }
            else
            {
                Node current = RootNode;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (data < current.Data)
                    {
                        current = current.LeftNode;
                        if (current == null)
                        {
                            parent.LeftNode = node;
                            break;
                        }
                    }
                    else
                    {
                        current = current.RightNode;
                        if (current == null)
                        {
                            parent.RightNode = node;
                            break;
                        }
                    }
                }
            }
        }

        public void Traversing(Node node)
        {
            if (node == null)
                return;

            Traversing(node.LeftNode);
            Console.Write($"{node.Data} ");
            Traversing(node.RightNode);
        }

        public Node Find(int Data)
        {
            Node node = RootNode;

            while (node.Data != Data)
            {
                node = Data < node.Data ? node.LeftNode : node.RightNode;

                if (node == null)
                    return null;
            }
            return node;
        }

        public Node GetMinimum(Node fromNode = null)
        {
            Node current = fromNode??RootNode;

            while(current.LeftNode != null)
            {
                current = current.LeftNode;
            }

            return current;
        }

        public Node GetMaximum(Node fromNode = null)
        {
            Node current = fromNode??RootNode;

            while(current.RightNode != null)
            {
                current = current.RightNode;
            }

            return current;
        }

        public void Delete(int Data)
        {
            Node current = RootNode;
            Node parent = RootNode;
            bool isLeftChildNode= false;

            while (current.Data != Data)
            {
                parent = current;
                isLeftChildNode = Data < current.Data ? true : false;                
                current = Data < current.Data ? current.LeftNode : current.RightNode;

                if (current == null)
                    return;
            }

            if (current.LeftNode == null && current.RightNode == null)
            {
                DeleteNodeWithNoChild(parent, current, isLeftChildNode);
            }
            else if (current.LeftNode == null ^ current.RightNode == null)
            {
                DeleteNodeWithOneChild(parent, current, isLeftChildNode);
            }
            else
            {
                DeleteNodeWithTwoChilds(current);
            }
        }

        private void DeleteNodeWithNoChild(Node parent, Node current, bool isLeftChildNode)
        {
            if (current == RootNode)
            {
                RootNode = null;
            }
            else if (isLeftChildNode)
            {
                parent.LeftNode = null;
            }
            else
            {
                parent.RightNode = null;
            }
        }

        private void DeleteNodeWithOneChild(Node parent, Node current, bool isLeftChildNode)
        {
            Node childNode = current.RightNode == null ? current.LeftNode : current.RightNode;

            if (current == RootNode)
            {
                RootNode = childNode;
            }
            else if (isLeftChildNode) 
            {
                parent.LeftNode = childNode;
            }
            else
            {
                parent.RightNode = childNode;
            }
        }

        private void DeleteNodeWithTwoChilds(Node current)
        {
            Node successor = GetMinimum(current.RightNode);

            int data = successor.Data;

            Delete(successor.Data);

            current.Data = data;
        }

        
    }
}
