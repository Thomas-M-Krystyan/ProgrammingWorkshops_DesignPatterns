using Iterator.Exercise.Data;
using Iterator.Exercise.TraverseStrategies;
using System;

namespace Iterator
{
    public static class Program
    {
        public static void Main()
        {
            // Standard Graph
            Graph graph = new(size: 10);

            // Using BFS iterator
            BFS_Strategy bfs = new(graph, isLeftHanded: true);

            foreach (Node node in bfs)  // NOTE: Implement the BFS iterator
            {
                if (node.Value == "H")
                {
                    Console.WriteLine("BFS iterator found letter \"H\"");
                }
            }

            // Using DFS iterator
            DFS_Strategy dfs = new(graph, isLeftHanded: true);

            foreach (Node node in dfs)  // NOTE: Implement the DFS iterator
            {
                if (node.Value == "H")
                {
                    Console.WriteLine("DFS iterator found letter \"H\"");
                }
            }
        }
    }
}
