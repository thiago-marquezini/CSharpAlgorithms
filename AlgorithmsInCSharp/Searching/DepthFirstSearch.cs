using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgorithmsInCSharp.Searching.DFS
{
    /*
     * The Depth-first search (DFS) algorithm is used for traversing graph or tree data structures. The traversing process starts from a chosen vertice and explores all of it´s adjacent vertices, keeping track of the ones that was already visited and using a recursive process to explore the adjacent vertices. 
     */
    public class DepthFirstSearchSample
    {
        public static bool SearchSample()
        {
            Graph graph = new Graph(10);
            graph.addEdge(1, 2);
            graph.addEdge(1, 3);
            graph.addEdge(2, 4);
            graph.addEdge(3, 1);
            graph.addEdge(3, 4);
            graph.addEdge(4, 5);
            graph.addEdge(4, 7);

            graph.DFS(1);

            return true;
        }
    }

    class Graph
    {
        private int _numberVertices;
        private List<int>[] _adjacentsArray;

        public Graph(int numberVertices)
        {
            _numberVertices = numberVertices;
            _adjacentsArray = new List<int>[numberVertices];
            for(int i = 0; i < numberVertices; i++)
            {
                _adjacentsArray[i] = new List<int>();
            }
        }

        public void addEdge(int verticeNumber, int value)
        {
            _adjacentsArray[verticeNumber].Add(value);
        }

        public void TraverseDFS(int vertice, bool[] visited)
        {
            visited[vertice] = true;

            Console.WriteLine(Environment.NewLine + vertice + " Traversed");
            
            Console.WriteLine($"Adjacent vertices: {(_adjacentsArray[vertice].Count() == 0 ? "none" : string.Join(", ", _adjacentsArray[vertice]))}");
            for (int i = 0; i < _adjacentsArray[vertice].Count(); i++)
            {
                int adjacentVertice = _adjacentsArray[vertice][i];
                if (!visited[adjacentVertice])
                {
                    TraverseDFS(adjacentVertice, visited);
                }
                else
                {
                    Console.WriteLine($"{adjacentVertice} already visited");
                }
            }
        }

        public void DFS(int vertice)
        {
            bool[] visited = new bool[_numberVertices];

            TraverseDFS(vertice, visited);
        }
    }
}
