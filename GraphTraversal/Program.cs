using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Graph graph = new Graph();

        graph.AddEdge(1, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 4);
        graph.AddEdge(2, 5);
        graph.AddEdge(3, 6);
        graph.AddEdge(4, 5);
        Console.WriteLine("Depth-First Search:");
        graph.DFS(1); 
        Console.WriteLine("Breadth-First Search:");
        graph.BFS(1); 
    }

    class Graph
    {
        private Dictionary<int, List<int>> adjacencyList;

        public Graph()
        {
            adjacencyList = new Dictionary<int, List<int>>();
        }

        public void AddEdge(int source, int destination)
        {
            if (!adjacencyList.ContainsKey(source))
            {
                adjacencyList[source] = new List<int>();
            }

            adjacencyList[source].Add(destination);
            if (!adjacencyList.ContainsKey(destination))
            {
                adjacencyList[destination] = new List<int>();
            }

            adjacencyList[destination].Add(source);
        }

        public void DFS(int start)
        {
            HashSet<int> visited = new HashSet<int>();
            DFSRecursive(start, visited);
            Console.WriteLine();
        }

        private void DFSRecursive(int node, HashSet<int> visited)
        {
            if (visited.Contains(node))
                return;
            Console.Write(node + " ");
            visited.Add(node);
            if (adjacencyList.ContainsKey(node))
            {
                foreach (var neighbor in adjacencyList[node])
                {
                    DFSRecursive(neighbor, visited);
                }
            }
        }

        public void BFS(int start)
        {
            HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited.Add(start);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                Console.Write(node + " ");
                if (adjacencyList.ContainsKey(node))
                {
                    foreach (var neighbor in adjacencyList[node])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            Console.WriteLine();
        }
    }
}